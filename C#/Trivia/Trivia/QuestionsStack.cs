using System;
using System.Collections.Generic;
using System.Linq;

namespace Trivia
{
    public class QuestionsStack
    {
        private readonly string _category;
        private readonly LinkedList<string> _questions;

        public QuestionsStack(string category, IQuestionsRepository questionsRepository)
        {
            _category = category;
            _questions = questionsRepository.GetQuestions(_category);
        }

        public void AskQuestionAndDiscardIt()
        {
            Console.WriteLine("The category is " + _category);
            Console.WriteLine(_questions.First());
            _questions.RemoveFirst();
        }
    }
}