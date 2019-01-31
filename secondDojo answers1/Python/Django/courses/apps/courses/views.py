# Create your views here.

from django.shortcuts import render, HttpResponse, redirect
from django.contrib import messages
from .models import * 

def index(request):
    context = {
        'course': Course.objects.all()
    }
    print('*'*70,Course.objects.all())
    print('*'*70,"Hello: \n", context)
    return render (request, 'courses/index.html', context)

def create_post(request):
    # post route
    # print(request.POST)
    # errors= Course.objects.validate_course(request.POST)

    # if len(errors):
    #     for key, value in errors.items():
    #         messages.error(request, value)
    #     return redirect ('/') 

    Course.objects.create(
        name= request.POST['name'],
        description= request.POST['description']
    )
    return redirect ('/')

# def add(request):
#     course= request.POST['first_name']
#     last_name= request.POST['last_name']
#     email= request.POST['email']
#     User.objects.create(first_name= first_name, last_name=last_name, email=email)
#     return redirect ('/')
    
# def edit(request, id):
#     user= User.objects.get(id=id)
#     context={
#         'first_name': user.first_name,
#         'last_name': user.last_name,
#         'email': user.email,
#         'id': user.id
#     }
#     return render (request, 'semirestful_users/edit.html', context)

def remove_confirm(request, id):
    #get route info
    courses = Course.objects.get(id=id)
    context = {
        "course": course
    }
    return render(request, 'courses/remove_confirm', context)
