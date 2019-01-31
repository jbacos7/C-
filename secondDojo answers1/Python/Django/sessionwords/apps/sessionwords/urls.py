from django.conf.urls import url
from . import views        
urlpatterns = [
    url(r'^$', views.index),
    url(r'^createword$',views.createword),
    url(r'^delete$',views.delete)

]
