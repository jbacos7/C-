
from __future__ import unicode_literals
from django.shortcuts import render, HttpResponse, redirect
def index(request):
    location= ['Paris', 'MilkyWay', 'Chicago', 'Santorini', 'USA', 'NewYork', 'Milan', 'Orlando']
    language= ['Python', 'JavaScript', 'C#', 'C++', 'MEAN', 'Ruby', 'HTML','CSS']
    context= {
        'location1': location,
        'language1': language
    }
    print (context)
    return render (request, 'survey/index.html', context)

def create(request):
    request.session['name']= request.POST['name']
    request.session['location']= request.POST['location']
    request.session['language']= request.POST['language']
    request.session['message']= request.POST['message']
    return redirect ('/success')

def success(request):
    context:{
        'name': request.session['name'],
        'location': request.session['location'],
        'language': request.session['language'],
        'message': request.session['message']
    }
    return render(request, 'survey/success.html' )

def back (request):
    return redirect('/')


