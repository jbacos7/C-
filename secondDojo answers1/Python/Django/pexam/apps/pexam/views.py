# Create your views here.
from __future__ import unicode_literals
from django.shortcuts import render, HttpResponse, redirect
from .models import *
from django .db import models 
from django.contrib.messages import get_messages
import bcrypt
import re

def index(request):
    # user = User.objects.get(id=request.session['user_id'])
    # context= {
    #     'user': User.objects.all(),
    #     'wish': Wish.objects.filter(item_id=request.session['user_id'])
    # }
    return render(request, "pexam/index.html")

def register(request):
    errors= User.objects.registermodel(request.POST)
    if len(errors):
        for key, value in errors.items():
            messages.error(request, value)
        return redirect('/')
    else: 
        password= bcrypt.hashpw(request.POST["password"].encode() , bcrypt.gensalt())
        user= User.objects.create(first_name= request.POST['first_name'], last_name=request.POST['last_name'], email=request.POST['email'], password= password) 
        request.session['first_name']=request.POST['first_name']
        request.session['user_id']= user.id
        return redirect ('/show')

def login(request):
    errors= User.objects.loginmodel(request.POST)
    if len(errors):
        for key, value in errors.items():
            messages.error(request, value)
        return redirect ('/')
    else: 
        request.session['first_name']=User.objects.get(email=request.POST['email']).first_name
        request.session['user_id'] = User.objects.get(email= request.POST['email']).id
        return redirect ('/show')

def logout(request):
    if "user_id" not in request.session:
        return redirect ('/')
    del request.session['user_id']
    return redirect ('/')

def destroy(request, wid):
    if "user_id" not in request.session:
        return redirect ('/')
    wish= Wish.objects.get(id=wid)
    wish.delete()
    return redirect('/show')

def show(request):
    if "user_id" not in request.session:
        return redirect ('/')
    context={
        'user': User.objects.get(id=request.session['user_id']),
        'wishes': Wish.objects.filter(item_id=request.session['user_id']),
        'allwishes': Wish.objects.filter(granted= True)
    }
    return render (request, 'pexam/show.html', context)

def add(request):
    if "user_id" not in request.session:
        return redirect ('/')
    user = User.objects.get(id=request.session['user_id'])
    context= {
        'first_name': request.session['first_name']
    }
    # wish= request.POST['wish']
    # description= request.POST['description']
    return render (request, 'pexam/create.html', context)

def createwish(request):
    if "user_id" not in request.session:
        return redirect ('/')
    user_id = request.session['user_id']
    errors= Wish.objects.wishmodel(request.POST)
    if len(errors):
        for key, value in errors.items():
            messages.error(request, value)
        return redirect ('/add')
    Wish.objects.create(item= request.POST['item'], description= request.POST['description'], item_id = User.objects.get(id = user_id))
    return redirect ('/show')

def grantwish(request, wid):
    if "user_id" not in request.session:
        return redirect ('/')
    wish= Wish.objects.get(id=wid)
    wish.granted= True
    wish.save()
    return redirect ('/show')

def edit(request, wid):        
    if "user_id" not in request.session:
        return redirect ('/')
    context = {
        'user': User.objects.get(id = request.session['user_id']),
        'wish': Wish.objects.get(id=wid)
    }
    return render (request, 'pexam/edit.html', context)

def editwish (request, wid):
    if "user_id" not in request.session:
        return redirect ('/')
    errors= Wish.objects.wishmodel(request.POST)
    if len(errors):
        for key, value in errors.items():
            messages.error(request, value)
        context = {
            'user': User.objects.get(id = request.session['user_id']),
            'wish': Wish.objects.get(id=wid)
        }
        return render (request, 'pexam/edit.html', context)
        
    print("=== EDIT WISH++++++")
    wish= Wish.objects.get(id= wid)
    wish.item = request.POST['item']
    wish.description = request.POST['description']
    wish.save()
    return redirect ('/show')

def stats(request):
    if "user_id" not in request.session:
        return redirect ('/')
    print("++++++++++++++++++IN STATS+++++++++++++++++")
    user= User.objects.get(id=request.session['user_id'])
    context= {
        'user': user,
        'granted_wishes': Wish.objects.filter(item_id= user, granted= True).count(),
        'pending_wishes': Wish.objects.filter(item_id= user, granted= False).count()
    }
    
    return render (request, 'pexam/stats.html', context)

    # # run the query --- and get an object back
    # wish = Wish.objects.get(id=2)
    # # interact with it as an object with dot notation and the attributes that belong to the object
    # wish.created_at
    