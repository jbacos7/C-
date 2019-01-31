# Create your views here.
from __future__ import unicode_literals
from django.shortcuts import render, HttpResponse, redirect

def index(request):
    response = "This is the index route. Also, placeholder to later display all the list of blogs"
    return HttpResponse(response)
def new(request):
    response = "This is new new new new new."
    return HttpResponse (response)
def create(request):
    response = "This is create create create create."
    return redirect('/blogs')
def show(request, num):
    response = "This is a placeholder for SHOW blog   " + num
    return redirect ('/{{number}}/edit')
def edit(request, num):
    response = "This is a placeholder for EDIT blog  " + num
    return HttpResponse(response)
def delete(request):
    request.session.clear()
    return redirect('/')  



