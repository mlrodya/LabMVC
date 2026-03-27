import datetime

from django.contrib import admin
from django.db import models
from django.utils import timezone

class Question(models.Model):
    question_text = models.CharField("Treść pytania", max_length=200)
    pub_date = models.DateTimeField("Data publikacji")

    def __str__(self):
        return self.question_text

    @admin.display(
        boolean=True,
        ordering="pub_date",
        description="Opublikowano niedawno?",
    )
    def was_published_recently(self):
        now = timezone.now()
        return now - datetime.timedelta(days=1) <= self.pub_date <= now

class Choice(models.Model):
    question = models.ForeignKey(Question, on_delete=models.CASCADE)
    choice_text = models.CharField("Treść odpowiedzi", max_length=200)
    votes = models.IntegerField("Liczba głosów", default=0)

    def __str__(self):
        return self.choice_text