from __future__ import unicode_literals
from django.shortcuts import render, HttpResponse, redirect
from .models import *
from django .db import models 
from django.contrib.messages import get_messages
import bcrypt
import re
import datetime

def index(request):
    return render(request, "pexam3/index.html")

def register(request):
    errors = User.objects.registermodel(request.POST)
    if len(errors):
        for key, value in errors.items():
            messages.error(request, value)
        return redirect('/')
    else: 
        password = bcrypt.hashpw(request.POST["password"].encode() , bcrypt.gensalt())
        user = User.objects.create(first_name= request.POST['first_name'], last_name=request.POST['last_name'], email=request.POST['email'], password= password) 
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
####################

def logout(request):
    if "user_id" not in request.session:
        return redirect ('/')
    del request.session['user_id']
    return redirect ('/')

def delete(request, qid):
    if "user_id" not in request.session:
        return redirect ('/')
    if Quote.objects.get(id=qid).created_by.id != request.session["user_id"]: 
        messages.error(request, 'Only person who created the quote can delete it.')
        return redirect('/show')   
    quote= Quote.objects.get(id=qid)
    quote.delete()
    return redirect('/show')

#####################

def show(request):
    if "user_id" not in request.session:
        return redirect ('/')
    user= User.objects.get(id= request.session['user_id'])
    allquotes= Quote.objects.all()
    # #user from the Join table in Models
    context={
        'user': user,
        'allquotes': allquotes,
    #     'exclude': exclude,
    }
    return render (request, 'pexam3/show.html', context)

######################

def add(request):
    if "user_id" not in request.session:
        return redirect ('/')
    user = User.objects.get(id=request.session['user_id'])
    context= {
        'first_name': request.session['first_name']
    }
    return render (request, 'pexam3/show.html', context)

def createquote(request):
    if "user_id" not in request.session:
        return redirect ('/')
    user_id = request.session['user_id']
    errors = Quote.objects.quotevalid(request.POST)
    if len(errors):
        for key, value in errors.items():
            messages.error(request, value)
        return redirect ('/show')
    Quote.objects.create(quote= request.POST['quote'], author= request.POST['author'], created_by = User.objects.get(id = user_id))
    return redirect ('/show')

###########
def edit(request, uid):
    if "user_id" not in request.session:
        return redirect ('/')
    user= User.objects.get(id=uid)
    context={
        'user': user,
        'first_name': user.first_name,
        'last_name': user.last_name,
        'email': user.email,
        'id': user.id
    }
    return render (request, 'pexam3/edit.html', context)

def updateuser(request, uid):
    if "user_id" not in request.session:
        return redirect ('/')
    user= User.objects.get(id= uid)
    user.first_name= request.POST['first_name']
    user.last_name= request.POST['last_name']
    user.email= request.POST['email']
    user.save()
    return redirect ('/show')

##############
def viewquotes(request, uid):
    if "user_id" not in request.session:
        return redirect ('/')    
    user = User.objects.get(id=uid)
    quotes= Quote.objects.filter(created_by=user).all()
    context={
        'user': user,
        'quotes': quotes,
        # 'show': user
    }
    return render (request, 'pexam3/viewquotes.html', context)
