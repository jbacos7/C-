
# Create your models here.
from __future__ import unicode_literals
from django.db import models
import re, bcrypt
from datetime import date
EMAIL_REGEX = re.compile(r'^[a-zA-Z0-9.+_-]+@[a-zA-Z0-9._-]+\.[a-zA-Z]+$')

class UserManager(models.Manager):
    def registerValidator(self, form_data):
        errors = {}
        print('=== REGISTER VALIDATOR ===')
     #  FIRST NAME
        if len(form_data['fn']) == 0:
            errors['first'] = "Must enter first name."
        elif len(form_data['fn']) < 2:
            errors['first'] = "First name must be at least 2 characters."
     #  LAST NAME
        if len(form_data['ln']) == 0:
            errors['last'] = "Must enter last name."
        elif len(form_data['ln']) < 2:
            errors['last'] = "Last name must be at least 2 characters."
     # EMAIL
        user = User.objects.filter(email=form_data['email'])
        if len(form_data['email']) == 0:
            errors['email'] = "Must enter email adress."
        elif EMAIL_REGEX.match(form_data['email']) == None:
            errors['email'] = "Email must be in valid email format."
        elif len(user) != 0:
            errors['email'] = "Email already in use."
     # Password
        if len(form_data['password']) == 0:
            errors['password'] = "Must enter password."
        elif len(form_data['password']) < 6:
            errors['password'] = "Password too short."
        elif form_data['password'] != form_data['cpass']:
            errors['mpass'] = "Your passwords don't match."
        return errors

    def loginValidator(self, inputs):
        print('=== LOGIN VALIDATOR ===')
        user = User.objects.filter(email=inputs['email'])
        Logerrors = {}
        if len(inputs['email']) == 0:
            Logerrors['email'] = "Must enter an email."            
        elif not user:
            Logerrors['email'] = "Invalid email address."
        if len(inputs['password']) == 0:
            Logerrors['password'] = "Must enter your password."
        elif not bcrypt.checkpw(inputs['password'].encode(), User.objects.get(email=inputs['email']).password.encode()):
            Logerrors['password'] = "Wrong password."
        return Logerrors

    def tripValidator(self, job_inputs):
        print('=== JOB VALIDATOR ===')
        Logerrors = {}
     # LOCATION
        if len(job_inputs['dest']) == 0:
            Logerrors['dest'] = "Must enter a Destination."            
        elif len(job_inputs['dest']) < 2:
            Logerrors['dest'] = "Destination entry is too short."
     # DESCRIPTION
        if len(job_inputs['desc']) == 0:
            Logerrors['desc'] = "Must have a description."            
        elif len(job_inputs['desc']) < 2:
            Logerrors['desc'] = "Your description is too short."
     # START DATE
        if len(job_inputs['dtf']) == 0:
            Logerrors['dtf'] = "Must Enter Start Date."        
     # END DATE
        if len(job_inputs['dtt']) == 0:
            Logerrors['de'] = "Must Enter End Date."

        sd = job_inputs['dtf']
        ed = job_inputs['dtt']
        

        return Logerrors

class User(models.Model):
    fn = models.CharField(max_length=255)
    ln = models.CharField(max_length=255)
    email = models.CharField(max_length=255)
    password = models.CharField(max_length=255)
    
    created_at = models.DateTimeField(auto_now_add=True)
    updated_at = models.DateTimeField(auto_now=True)
    objects = UserManager()

class Trip(models.Model):
    dest = models.CharField(max_length=50)
    desc = models.CharField(max_length=150)
    dtf = models.DateField(null=True)
    dtt = models.DateField(null=True)
    creator = models.ForeignKey(User, related_name='Trip')

    created_at = models.DateTimeField(auto_now_add=True)
    updated_at = models.DateTimeField(auto_now=True)
    objects = UserManager()

class Joined_Trip(models.Model):
    user_id = models.ForeignKey(User, related_name='Joining')
    trip_id = models.ForeignKey(Trip, related_name='Joining')
    
    created_at = models.DateTimeField(auto_now_add=True)
    updated_at = models.DateTimeField(auto_now=True)

    objects = UserManager()