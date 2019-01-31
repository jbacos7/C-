from __future__ import unicode_literals
from django.db import models
from django.contrib import messages
from django.contrib.messages import get_messages
import re
import bcrypt
from datetime import date, datetime

EMAIL_REGEX = re.compile(r'^[a-zA-Z0-9.+_-]+@[a-zA-copyZ0-9._-]+\.[a-zA-Z]+$')

class UserManager(models.Manager):
    def registermodel(self, postData):
        errors= {}
        if len(postData["first_name"]) < 2:
            errors['first_name'] = ("First name is required and must be greater than 2 characters.")
        if len(postData["last_name"]) < 2:
            errors['last_name'] = ("Last name is required and must be greater than 2 characters.")
        if not EMAIL_REGEX.match(postData["email"]):
            errors['email']=  ("Invalid email format.")
        if len(postData["password"]) < 8:
            errors['password'] = ("Password is required and must be greater than 8 characters.")
        if postData["password"] != postData["pwconf"]:
            errors['password']=  ("Passwords do not match.")
        if User.objects.filter(email=postData["email"]).count() > 0:
            errors['email']=  ("This email already exists.")
        return errors
    
    def loginmodel(self, postData):
        errors= {}
        # if user is in DB- email
        user = User.objects.filter(email=postData['email'])
        if len(user) != 1:
            errors['email']= "This email is not registered."
        else: 
            pwvalid = bcrypt.checkpw(postData['password'].encode(), user[0].password.encode())
            if pwvalid == False:
                errors['password']= "You could not be logged in."
        return errors

    def tripmodel(self, postData):
        errors={}
        if len(postData["dest"]) < 3:
            errors['dest'] = "Trip is required and must be greater than 3 characters."
        if len(postData["description"]) < 3:
            errors['description'] = "Description is required and must be greater than 3 characters."
        if len(postData["start_date"]) == 0:
            errors['start_date']= "Must input a start date."
        if len(postData["end_date"]) == 0:
            errors['end_date']= "Must input an end date."
        if postData['start_date'] > postData['end_date']:
            errors['dates']= "Travel dates are not valid. Please check your travel dates again."
        return errors
        past= datetime.strptime(postData['start_date'], "%Y-%m-%d")
        present= datetime.now()
        if past.date() < present.date():
            errors['future']= "You must travel in the future."
        return errors
    
class User(models.Model):
    first_name = models.CharField(max_length=100)
    last_name = models.CharField(max_length=100)
    email = models.CharField(max_length=100)
    password = models.CharField(max_length=255)
    created_at = models.DateTimeField(auto_now_add = True)
    updated_at = models.DateTimeField(auto_now = True)
    objects = UserManager()

class Trip(models.Model):
    # user= models.CharField(max_length= 100)
    dest = models.CharField(max_length=100)
    description = models.CharField(max_length=255)
    # granted = models.BooleanField(default= False)
    created_by = models.ForeignKey(User, related_name="Trip", on_delete=models.CASCADE)
    #USED TO BE TRIP ID 

    start_date = models.DateField(null= True)
    end_date = models.DateField(null= True)
    created_at = models.DateTimeField(auto_now_add = True)
    updated_at = models.DateTimeField(auto_now = True)
    objects = UserManager()

class Join(models.Model):
    user = models.ForeignKey(User, related_name="Joining", on_delete=models.CASCADE)
    trip = models.ForeignKey(Trip, related_name= "Joining", on_delete=models.CASCADE)
    created_at = models.DateTimeField(auto_now_add = True)
    updated_at = models.DateTimeField(auto_now = True)
    objects = UserManager()
