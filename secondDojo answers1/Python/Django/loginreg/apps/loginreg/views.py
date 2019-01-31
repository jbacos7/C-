# Create your views here.
from __future__ import unicode_literals
from django.shortcuts import render, HttpResponse, redirect
from .models import *
from django .db import models 
from django.contrib.messages import get_messages
import bcrypt
import re

def index(request):
    # context= {
    #     'user': User.objects.all()
    # }
    return render(request, "loginreg/index.html")

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
        return redirect ('/success')

def login(request):
    errors= User.objects.loginmodel(request.POST)
    if len(errors):
        for key, value in errors.items():
            messages.error(request, value)
        return redirect ('/')
    else: 
        request.session['first_name']=User.objects.get(email=request.POST['email']).first_name
        request.session['user_id'] = User.objects.get(email= request.POST['email']).id
        return redirect ('/success')

def success (request):
    if "user_id" not in request.session:
        return redirect ('/')
    context= {
        "first_name": request.session['first_name']
    }
    return render (request, 'loginreg/success.html', context)

def logout(request):
    del request.session['user_id']
    return redirect ('/')


