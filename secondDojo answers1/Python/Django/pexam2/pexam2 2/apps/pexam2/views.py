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

def logout(request):
    if "user_id" not in request.session:
        return redirect ('/')
    del request.session['user_id']
    return redirect ('/')

def destroy(request, tid):
    if "user_id" not in request.session:
        return redirect ('/')
    if Job.objects.get(id=tid).trip_id.id != request.session["user_id"]: 
        messages.error(request, 'Only person who created trip can delete it.')
        return redirect('/show')   
    job= Job.objects.get(id=tid)
    job.delete()
    return redirect('/show')

def show(request):
    if "user_id" not in request.session:
        return redirect ('/')
    context={
        'user': User.objects.get(id=request.session['user_id']),
        'jobs': Job.objects.filter(trip_id=request.session['user_id']),
        'alljobs': Job.objects.filter(granted= True)
    }
    return render (request, 'pexam2/show.html', context)


def add(request):
    if "user_id" not in request.session:
        return redirect ('/')
    user = User.objects.get(id=request.session['user_id'])
    context= {
        'first_name': request.session['first_name']
    }
    # job= request.POST['job']
    # description= request.POST['description']
    return render (request, 'pexam2/create.html', context)

def createtrip(request):
    if "user_id" not in request.session:
        return redirect ('/')
    user_id = request.session['user_id']
    errors= Job.objects.jobmodel(request.POST)
    if len(errors):
        for key, value in errors.items():
            messages.error(request, value)
        return redirect ('/add')
    Job.objects.create(dest= request.POST['dest'], description= request.POST['description'], trip_id = User.objects.get(id = user_id))
    return redirect ('/show')

def granttrip(request, tid):
    if "user_id" not in request.session:
        return redirect ('/')
    job= Job.objects.get(id=tid)
    job.granted= True
    job.save()
    return redirect ('/show')

def view(request, tid):
    if "user_id" not in request.session:
        return redirect ('/')
    user = User.objects.get(id=request.session['user_id'])
    job= Job.objects.get(id= tid)
    # tuid= User.objects.get
    # created_by= Joining.objects.get(id=id)
    context = {
        'user': user,
        'job': job,
        # 'created_by' : created_by
        # 'user_join': Joining.objects.filter(job_id= jobdest).all()
        # 'trip_dest': Joining.objects.filter(user_id= user).count()
        # 'pending_jobs': Job.objects.filter(trip_id= user, granted= False).all()
    }
    return render (request, 'pexam2/view.html', context)
#date = {%'%d-%m-%y"%}
# <!-- <th> {% '%d-%m-%y' %} </th> -->