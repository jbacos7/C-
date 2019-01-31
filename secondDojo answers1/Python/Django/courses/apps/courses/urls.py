   
from django.conf.urls import url
from . import views        
urlpatterns = [
    url(r'^$', views.index),
    url(r'^create', views.create_post),
    url(r'^remove_confirm', views.remove_confirm),

]                
    # url(r'^new', views.new, name= "new"),
