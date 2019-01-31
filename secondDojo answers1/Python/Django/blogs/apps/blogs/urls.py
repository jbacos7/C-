from django.conf.urls import include, url
from . import views

urlpatterns = [
    url(r'^blogs/$', views.index, name= "index"),
    url(r'^blogs/new/$', views.new, name= "new"),
    url(r'^blogs/$', views.create, name= "create"),
    url(r'^blogs/(?P<num>\d+)$', views.show, name= "show"),
    url(r'^blogs/(?P<num>\d+/edit)$', views.edit, name= "edit"),
    url(r'^blogs/delete$',views.delete)
]
