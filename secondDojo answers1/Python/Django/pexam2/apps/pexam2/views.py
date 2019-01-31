from __future__ import unicode_literals
from django.shortcuts import render, HttpResponse, redirect
from .models import *
from django .db import models 
from django.contrib.messages import get_messages
import bcrypt
import re
import datetime

def index(request):
    # user = User.objects.get(id=request.session['user_id'])
    # context= {
    #     'user': User.objects.all(),
    #     'trip': Wish.objects.filter(item_id=request.session['user_id'])
    # }
    return render(request, "pexam2/index.html")

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
#############

def logout(request):
    if "user_id" not in request.session:
        return redirect ('/')
    del request.session['user_id']
    return redirect ('/')

def delete(request, tid):
    if "user_id" not in request.session:
        return redirect ('/')
    if Trip.objects.get(id=tid).created_by.id != request.session["user_id"]: 
        messages.error(request, 'Only person who created trip can delete it.')
        return redirect('/show')   
    trip= Trip.objects.get(id=tid)
    trip.delete()
    return redirect('/show')

def canceltrip(request, tid):
    if "user_id" not in request.session:
        return redirect ('/')
    trip= Trip.objects.get(id= tid)
    user= User.objects.get(id=request.session["user_id"])
    jointrip= Join.objects.get(trip= trip, user= user)
    jointrip.delete()
    return redirect ('/show')
#############

def show(request):
    if "user_id" not in request.session:
        return redirect ('/')
    user= User.objects.get(id= request.session['user_id'])
    exclude= Join.objects.exclude(user=user)
    #user from the Join table in Models
    mytrips= Join.objects.filter(user=user)
    trips= Trip.objects.all()
    context={
        'trips': trips,
        'user': user,
        'exclude': exclude,
        'mytrips': mytrips,
        # 'jobs': Job.objects.filter(created_by=request.session['user_id']),
        # 'alltrips': Trip.objects.all()
    }
    return render (request, 'pexam2/show.html', context)


#############

def add(request):
    if "user_id" not in request.session:
        return redirect ('/')
    user = User.objects.get(id=request.session['user_id'])
    context= {
        'first_name': request.session['first_name']
    }
    return render (request, 'pexam2/create.html', context)

def createtrip(request):
    if "user_id" not in request.session:
        return redirect ('/')
    user_id = request.session['user_id']
    errors= Trip.objects.tripmodel(request.POST)
    if len(errors):
        for key, value in errors.items():
            messages.error(request, value)
        return redirect ('/add')
    Trip.objects.create(dest= request.POST['dest'], description= request.POST['description'], created_by = User.objects.get(id = user_id), start_date= request.POST['start_date'], end_date= request.POST['end_date'])
    return redirect ('/show')

def jointrip(request, tid):
    if "user_id" not in request.session:
        return redirect ('/')
    trip= Trip.objects.get(id=tid)
    user= User.objects.get(id=request.session["user_id"])
    Join.objects.create(user= user, trip= trip)
    return redirect ('/show')

#############

def viewtrip(request, tid):
    if "user_id" not in request.session:
        return redirect ('/')
    user = User.objects.get(id=request.session['user_id'])
    trip= Trip.objects.get(id= tid)
    context = {
        'user': user,
        'trip': trip,
    }
    return render (request, 'pexam2/viewtrip.html', context)
