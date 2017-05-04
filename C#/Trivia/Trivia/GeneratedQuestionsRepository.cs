using System.Collections.Generic;

namespace Trivia
{
    public interface IQuestionsRepository
    {
        LinkedList<string> GetQuestions(string category);
    }

    class FileQuestionsRepository : IQuestionsRepository
    {
        public LinkedList<string> GetQuestions(string category)
        {
            throw new System.NotImplementedException();
        }
    }

    public class GeneratedQuestionsRepository : IQuestionsRepository
    {
        public GeneratedQuestionsRepository()
        {
        }

        public LinkedList<string> GetQuestions(string category)
        {
            var questions = new LinkedList<string>();
            for (var i = 0; i < 50; i++)
            {
                questions.AddLast(category + " Question " + i);
            }
            return questions;
        }
    }
}