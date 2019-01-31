from django.shortcuts import render, HttpResponse, redirect
from .models import *
from django.contrib import messages

#DATE_INPUT_FORMATS = ['%d-%m-%Y']
#-----------------------------------
def index(request):
    print('=== INDEX ===')

    if ('user_id' not in request.session):
        print('=== NOT LOGGED IN ===')
        context = {'users': User.objects.all()}
        return render(request,'pexam22/Login.html', context)

    else:
        print('=== INDEX LOGGED IN===')
        context = {
            'user': User.objects.get(id=request.session['user_id']),
            'all_user_Trips': Joined_Trip.objects.all()
        }
        return render(request,'pexam22/Home.html', context)
#-----------------------------------
def addUser(request):
    print('=== ADD USER ===')
    errors = User.objects.registerValidator(request.POST)
    if len(errors):
        print('=== IS ERRORS ===')
        for key, value in errors.items():
            messages.error(request, value)
        return redirect('/')
    print('=== NO ERRORS ===')
    hash1 = bcrypt.hashpw(request.POST['password'].encode(), bcrypt.gensalt())
    User.objects.create(
        fn = request.POST['fn'],
        ln = request.POST['ln'],
        email=request.POST['email'],
        password=hash1
    )
    user = User.objects.get(email=request.POST['email'])
    request.session['user_id'] = user.id
    return redirect('/')
def login(request):
    print('=== LOGIN ===')
    errors = User.objects.loginValidator(request.POST)
    if len(errors):
        print('=== IS ERRORS ===')
        for key, value in errors.items():
            messages.error(request, value)
        return redirect('/')
    print('=== NO ERRORS ===')
    user = User.objects.get(email=request.POST['email'])
    request.session['user_id'] = user.id
    return redirect('/')
def logout(request):
    print('=== LOGOUT ===')
    del request.session['user_id']
    return redirect('/')
#-----------------------------------
def addTripGoTo(request):
    print('=== GOTO ADD TRIP ===')
    user = User.objects.get(id=request.session['user_id'])
    context = {'users': user}
    return render(request,'BeltFour/addTrip.html', context)
def addTrip(request):
    print('=== ADD TRIP ===')
    errors = User.objects.tripValidator(request.POST)
    if len(errors):
        print('=== IS ERRORS ===')
        for key, value in errors.items():
            messages.error(request, value)
        return redirect('/addTripGoTo')

    print('=== NO ERRORS ===')
    trip = Trip.objects.create(
        dest = request.POST['dest'],
        desc = request.POST['desc'],
        dtf = request.POST['dtf'],
        dtt = request.POST['dtt'],
        creator = User.objects.get(id=request.session['user_id'])
    )
    Joined_Trip.objects.create(
        user_id = User.objects.get(id=request.session['user_id']),
        job_id = trip
    )
    return redirect('/')
#-----------------------------------
def JoinTrip(request, jid):
    print('=== JOIN TRIP ===')
    Joined_Trip.objects.create(
        user_id = User.objects.get(id=request.session['user_id']),
        job_id = Trip.objects.get(id=jid)
    )
    return redirect('/')
#-----------------------------------
def cancel(request, jid):
    job = Trip.objects.get(id=jid)
    job.isGoing = False
    job.save()
    return redirect('/')
def deleteTrip(request, jid):
    print('=== DELETE JOB ===')
    deleteJob = Trip.objects.get(id=jid)
    deleteJob.delete()
    print('=== JOB DELETED ===')

    return redirect('/')
#-----------------------------------
def trips(request, jid):
    user = User.objects.get(id=request.session['user_id'])
    job = Trip.objects.get(id=jid)
    AllJobs = Trip.objects.all()
    joinings = Joined_Trip.objects.all()
    context = {
        'user': user,
        'job': job,
        'AllJobs': AllJobs,
        'joins': joinings
    }
    return render(request,'BeltFour/Trips.html', context)