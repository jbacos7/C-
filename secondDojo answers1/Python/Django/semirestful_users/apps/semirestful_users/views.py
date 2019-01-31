from __future__ import unicode_literals
from django.shortcuts import render, HttpResponse, redirect
from .models import *
def index(request):
    # User= User.objects.get(id=id)
    context={
        'user': User.objects.all()
    }
    return render (request, 'semirestful_users/index.html', context)

def new(request):
    return render (request, 'semirestful_users/new.html')

def add(request):
    first_name= request.POST['first_name']
    last_name= request.POST['last_name']
    email= request.POST['email']
    User.objects.create(first_name= first_name, last_name=last_name, email=email)
    return redirect ('/')
    
def edit(request, id):
    user= User.objects.get(id=id)
    context={
        'first_name': user.first_name,
        'last_name': user.last_name,
        'email': user.email,
        'id': user.id
    }
    return render (request, 'semirestful_users/edit.html', context)
    
def updateuser (request):
    user= User.objects.get(id=request.POST['id'])
    user.first_name= request.POST['first_name']
    user.last_name= request.POST['last_name']
    user.email= request.POST['email']
    user.save()
    ##validation would go here 
    return redirect ('/')

def show(request, id):
    user= User.objects.get(id=id)
    context={
        'first_name': user.first_name,
        'last_name': user.last_name,
        'email': user.email,
        'id': user.id
    }
    return render (request, 'semirestful_users/show.html', context)

def destroy(request, id):
    user= User.objects.get(id=id)
    user.delete()
    return redirect('/')
