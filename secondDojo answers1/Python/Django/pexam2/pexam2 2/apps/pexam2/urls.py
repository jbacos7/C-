from django.conf.urls import url
from . import views        
urlpatterns = [
    url(r'^$', views.index),
    url(r'^register', views.register),
    url(r'^login', views.login),
    url(r'^show', views.show),
    url(r'^add', views.add),
    url(r'^createtrip', views.createtrip),
    url(r'^logout', views.logout),
    url(r'^(?P<tid>\d+)/destroy', views.destroy),
    url(r'^(?P<tid>\d+)/granttrip', views.granttrip),
    url(r'^(?P<tid>\d+)/view', views.view),

    # url(r'^stats', views.stats)


]                
