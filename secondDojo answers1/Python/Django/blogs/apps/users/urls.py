from django.conf.urls import url
from . import views        
urlpatterns = [
    url(r'^register/$', views.index, name= "index"),
    url(r'^login/$', views.login, name= "login"),
    url(r'^new/$', views.new, name= "new"),
    url(r'^users/$', views.users, name= "users"),
]                
