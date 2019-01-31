
# Create your views here.
from __future__ import unicode_literals
from django.shortcuts import render, HttpResponse, redirect
def index(request):
    response = "placeholder to later display all the list of blogs"
    return HttpResponse(response)
