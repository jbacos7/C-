# -*- coding: utf-8 -*-
# Generated by Django 1.10 on 2018-08-23 15:13
from __future__ import unicode_literals

from django.db import migrations


class Migration(migrations.Migration):

    dependencies = [
        ('pexam3', '0002_like_quote'),
    ]

    operations = [
        migrations.RenameModel(
            old_name='Like',
            new_name='Join',
        ),
    ]
