import datetime

from django.test import TestCase
from django.utils import timezone
from django.urls import reverse

from .models import Question

class QuestionModelTests(TestCase):
    def test_was_published_recently_with_future_question(self):
        """
        was_published_recently() zwraca False dla pytań,
        których pub_date jest w przyszłości.
        """
        time = timezone.now() + datetime.timedelta(days=30)
        future_question = Question(pub_date=time)
        self.assertIs(future_question.was_published_recently(), False)


def create_question(question_text, days):
    """
    Tworzy pytanie z podanym tekstem i przesunięciem w dniach
    (ujemne dla przeszłości, dodatnie dla przyszłości).
    """
    time = timezone.now() + datetime.timedelta(days=days)
    return Question.objects.create(question_text=question_text, pub_date=time)


class QuestionIndexViewTests(TestCase):
    def test_no_questions(self):
        """Jeśli nie ma pytań, wyświetla odpowiedni komunikat."""
        response = self.client.get(reverse("polls:index"))
        self.assertEqual(response.status_code, 200)
        self.assertContains(response, "Brak dostępnych ankiet.")
        self.assertQuerySetEqual(response.context["latest_question_list"], [])

    def test_past_question(self):
        """Pytania z przeszłości są wyświetlane na stronie głównej."""
        question = create_question(question_text="Pytanie z przeszłości.", days=-30)
        response = self.client.get(reverse("polls:index"))
        self.assertQuerySetEqual(
            response.context["latest_question_list"],
            [question],
        )

    def test_future_question(self):
        """Pytania z przyszłości NIE są wyświetlane na stronie głównej."""
        create_question(question_text="Pytanie z przyszłości.", days=30)
        response = self.client.get(reverse("polls:index"))
        self.assertContains(response, "Brak dostępnych ankiet.")
        self.assertQuerySetEqual(response.context["latest_question_list"], [])


class QuestionDetailViewTests(TestCase):
    def test_future_question(self):
        """Widok szczegółów dla pytania z przyszłości zwraca 404 (nie znaleziono)."""
        future_question = create_question(question_text="Przyszłe pytanie.", days=5)
        url = reverse("polls:detail", args=(future_question.id,))
        response = self.client.get(url)
        self.assertEqual(response.status_code, 404)

    def test_past_question(self):
        """Widok szczegółów dla pytania z przeszłości wyświetla jego tekst."""
        past_question = create_question(question_text="Przeszłe pytanie.", days=-5)
        url = reverse("polls:detail", args=(past_question.id,))
        response = self.client.get(url)
        self.assertContains(response, past_question.question_text)