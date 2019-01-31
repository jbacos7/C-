
# Create your views here.
from __future__ import unicode_literals
from django.shortcuts import render, HttpResponse, redirect
from django.utils.crypto import get_random_string

def index(request):
    context = {
        "unique_id": get_random_string(length=14)
        # "time": strftime("%Y-%m-%d %H:%M %p", gmtime())
    }
    return render(request,'random_word/index.html', context)



    
def create(request):
    return redirect('/')