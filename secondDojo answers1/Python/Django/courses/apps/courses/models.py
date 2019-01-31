from __future__ import unicode_literals
from django.db import models

# Create your models here.
class CourseManger(models.Manager):
    def validate_course (self, form_data):
        errors= {}
    #EMPTY DICT TO KEEP TRACK OF ERRORS !! 
    #check if the name is present-- required
    #check if the name is at least 2 characters
        if len(form_data['name']) < 5:
            errors['name'] = "Name is required and must be at least 5 characters."
        #takes care of 2 chara as well as being blank - 0 chara- combined
    
        if len(form_data['description']) < 15:
            errors['description']= "Description is requred and must be at least 15 characters."
        return errors

class Course(models.Model):
    print('$'*70)
    name= models.CharField(max_length= 255)
    description= models.CharField(max_length= 255)
    created_at = models.DateTimeField(auto_now_add = True)
    updated_at = models.DateTimeField(auto_now = True)
    objects= CourseManger()