using System;
using System.Collections.Generic;
using System.Linq;

namespace Trivia
{
    internal class QuestionDeck
    {
        private List<Question> _questions;

        public QuestionDeck()
        {
            ShuffleDeck();
        }

        private void ShuffleDeck()
        {
            _questions = new List<Question>();
            for (int i = 0; i < 50; i++)
            {
                _questions.Add(new Question {Type = QuestionType.Pop, Number = i});
                _questions.Add(new Question {Type = QuestionType.Science, Number = i});
                _questions.Add(new Question {Type = QuestionType.Sport, Number = i});
                _questions.Add(new Question {Type = QuestionType.Rock, Number = i});
            }
        }

        public void AskQuestion(QuestionType category)
        {
            var question = _questions.FirstOrDefault(x => x.Type == category);
            if (question == null)
            {
                ShuffleDeck();
            }
            
            Console.WriteLine($"{question.Type} question {question.Number}");
            _questions.Remove(question);
        }
    }
}