from django.conf.urls import url, include
from . import views    
urlpatterns = [
    url(r'^$', views.index),
    url(r'^register', views.register),
    url(r'^login', views.login),
    url(r'^logout', views.logout),
    url(r'^show', views.show),
    url(r'^add', views.add),
    url(r'^createquote', views.createquote),
    url(r'^(?P<uid>\d+)/edit', views.edit),
    url(r'^(?P<uid>\d+)/updateuser', views.updateuser),
    url(r'^(?P<qid>\d+)/delete', views.delete),
    url(r'^(?P<uid>\d+)/viewquotes', views.viewquotes),
]               
