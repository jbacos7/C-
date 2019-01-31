from __future__ import unicode_literals
from django.shortcuts import render, HttpResponse, redirect
from time import gmtime, strftime

def index(request):        
    return render(request,'sessionwords/index.html')

    # temp_list.append({"word": "word", "color": "color", "show_big": True | False})
    # request.session['word'] = temp_list

def createword(request):
    datetime= strftime("%Y-%m-%d %H:%M %p", gmtime())
    bigwriting= 0
    smallwriting= 1
    # color= ['Red', 'Green', 'Purple', 'Blue']
    if 'words' not in request.session:
        request.session['words'] = []
    if 'bigwriting' in request.POST:
        showbig = 1
    else:
        showbig = 0

# temp_list.append({"word": "Django", "color": "blue", "show_big": showbig})
    if 'bigwriting' in request.POST:
        context= {
        'word': request.POST['saved'],
		'color': request.POST['color'],
        'showbig': 1,
		'time': datetime,
        }
    else:
        context= {
        'word': request.POST['saved'],
        'color': request.POST['color'],
        'showbig': 0,
        'time': datetime,
        }

    request.session['words'].append(context)
    request.session.modified= True

    print (request.session['words'])
    return redirect ('/')

    # saved_list.append({"word": "Django", "color": "blue", "show_big": False})
    # request.session['word'] = temp_list
    
def delete(request):
    request.session.clear()
    return redirect('/')


