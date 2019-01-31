# # Create your views here.
# from __future__ import unicode_literals
# from django.shortcuts import render, HttpResponse, redirect
# def index(request):
#     response = "Here's a placeholder function!"
#     return HttpResponse(response)


from django.shortcuts import render, HttpResponse, redirect
from time import gmtime, strftime
def index(request):
    context = {
        "time": strftime("%Y-%m-%d %H:%M %p", gmtime())
    }
    return render(request,'timedate/index.html', context)
