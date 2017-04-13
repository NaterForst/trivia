using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trivia
{
    public class QuestionStack
    {
        public string _category;

        public QuestionStack(string category)
        {
            _category = category;
        }

        private readonly List<Question> _stackQuestions = new List<Question>();

        public void AddQuestion(string quest, string resp)
        {
            var question = new Question(quest, resp);


            _stackQuestions.Add(question);

        }

    }
   /*
    private void AskQuestion()
    {
    if ( == "Pop")
    {
    Console.WriteLine(Questions.PopStack.First());
    QuestionStack..RemoveFirst();
    }
    if (CurrentCategory() == "Science")
    {
    Console.WriteLine(QuestionStack.ScienceQuestions.First());
    QuestionStack.ScienceQuestions.RemoveFirst();
    }
    if (CurrentCategory() == "Sports")
    {
    Console.WriteLine(QuestionStack.SportsQuestions.First());
    QuestionStack.SportsQuestions.RemoveFirst();
    }
    if (CurrentCategory() == "Rock")
    {
    Console.WriteLine(QuestionStack.RockQuestions.First());
    QuestionStack.RockQuestions.RemoveFirst();
    }
    * */
}

