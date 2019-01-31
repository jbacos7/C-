from django.conf.urls import url
from . import views        
urlpatterns = [
    url(r'^$', views.index),
    url(r'^register', views.register),
    url(r'^login', views.login),
    url(r'^show$', views.show),
    # url(r'^(?P<tid>\d+)/show', views.show),
    url(r'^add', views.add),
    url(r'^createtrip', views.createtrip),
    url(r'^logout', views.logout),
    url(r'^(?P<tid>\d+)/delete', views.delete),
    url(r'^(?P<tid>\d+)/canceltrip', views.canceltrip),
    url(r'^(?P<tid>\d+)/jointrip', views.jointrip),
    url(r'^(?P<tid>\d+)/view', views.viewtrip),

    # url(r'^stats', views.stats)


]                
