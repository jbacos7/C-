# Create your models here.
from __future__ import unicode_literals
from django.db import models

# Create your models here.

class User(models.Model):
    first_name= models.CharField(max_length=255)
    last_name= models.CharField(max_length=255)
    email= models.CharField(max_length=255)
    created_at= models.DateTimeField(auto_now_add = True)
    updated_at= models.DateTimeField(auto_now = True)
    def __repr__(self):
        return "<User object: {} {} {}>".format(self.first_name, self.last_name, self.email)

class Book(models.Model):
    name= models.CharField(max_length=255)
    desc= models.TextField(max_length=1000)
    created_at= models.DateTimeField(auto_now_add = True)
    updated_at= models.DateTimeField(auto_now = True)
    users_id= models.ForeignKey(User, related_name = 'uploaded_books')
    def __repr__(self):
        return "<User object: {} {} {}>".format(self.name, self.desc, self.users_id)

class Like(models.Model):
    user_id = models.ForeignKey(User, related_name = 'Book')
    book_id = models.ForeignKey(Book, related_name = 'User')
    def __repr__(self):
        return "<User object: {} {}>".format(self.user_id, self.book_id)