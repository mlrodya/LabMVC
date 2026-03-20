from django.db import models

class Question(models.Model):
    question_text = models.CharField("Treść pytania", max_length=200)
    pub_date = models.DateTimeField("Data publikacji")

    def __str__(self):
        return self.question_text

class Choice(models.Model):
    question = models.ForeignKey(Question, on_delete=models.CASCADE)
    choice_text = models.CharField("Treść odpowiedzi", max_length=200)
    votes = models.IntegerField("Liczba głosów", default=0)

    def __str__(self):
        return self.choice_text