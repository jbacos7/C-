from django.db import models

# Create your models here.
class Person (models.Model):
    name= models.CharField(max_length= 80)
    email= models.CharField(max_length= 80)

class Post (models.Model):
    content= models.CharField(max_length= 250)
    author= models.ForeignKey(Person, related_name= 'posts')