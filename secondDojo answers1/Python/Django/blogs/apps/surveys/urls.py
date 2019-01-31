from django.conf.urls import url
from . import views        
urlpatterns = [
    url(r'^surveys/$', views.index, name= "index"),
    url(r'^surveys/new/$', views.new, name= "new"),
]                
