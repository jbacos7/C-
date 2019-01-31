from django.conf.urls import url
from . import views        
urlpatterns = [
    url(r'^$', views.index, name= "index"),
    url(r'^new', views.new, name= "new"),
    url(r'^add', views.add, name= "add"),
    url(r'^(?P<id>\d+)/show', views.show, name= "show"),
    url(r'^(?P<id>\d+)/edit', views.edit, name= "edit"),
    url(r'^edit', views.updateuser, name= "updateuser"),
    url(r'^(?P<id>\d+)/destroy', views.destroy, name="destroy")
]                
