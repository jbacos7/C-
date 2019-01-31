from django.conf.urls import url
from . import views        
urlpatterns = [
    url(r'^JoinTrip/(?P<jid>\d+)$', views.JoinTrip),
    url(r'^deleteTrip/(?P<jid>\d+)$', views.deleteTrip),
    url(r'^cancel/(?P<jid>\d+)$', views.cancel),
    url(r'^trips/(?P<jid>\d+)$', views.trips),
    url(r'^addTripGoTo', views.addTripGoTo),
    url(r'^addTrip', views.addTrip),
    url(r'^addUser', views.addUser),
    url(r'^login', views.login),
    url(r'^logout', views.logout),
    url(r'^$', views.index)
]
  
