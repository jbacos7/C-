
# Create your views here.
from __future__ import unicode_literals
from django.shortcuts import render, HttpResponse, redirect
def index(request):
    response = "INDEX route for Surveys App!"
    return HttpResponse(response)
def new(request):
    response = "NEW route for Surveys App. Here's a placeholder function!"
    return HttpResponse(response)
