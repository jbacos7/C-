from django.conf.urls import url, include
from . import views    
urlpatterns = [
    url(r'^$', views.index),
    url(r'^register', views.register),
    url(r'^login', views.login),
    url(r'^show', views.show),
    url(r'^add', views.add),
    url(r'^createwish', views.createwish),
    url(r'^logout', views.logout),
    url(r'^(?P<wid>\d+)/destroy', views.destroy),
    url(r'^(?P<wid>\d+)/edit$', views.edit),
    url(r'^(?P<wid>\d+)/editwish', views.editwish),
    url(r'^(?P<wid>\d+)/grantwish', views.grantwish),
    url(r'^stats', views.stats)
]
