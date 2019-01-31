
# Create your views here.
from __future__ import unicode_literals
from django.shortcuts import render, HttpResponse, redirect
def index(request):
    response = "INDEX route for Users App! Here's a placeholder for users to create a new user record!"
    return HttpResponse(response)
def login(request):
    response = "LOGIN route for Users App. Here's a login placeholder function!"
    return HttpResponse(response)
def new(request):
    response = "INDEX route for Users App! Here's a placeholder for users to create a new user record!"
    return redirect ('/register')
def users(request):
    response: "This is a placeholder to later display all the list of users..!"
    return HttpResponse(response)