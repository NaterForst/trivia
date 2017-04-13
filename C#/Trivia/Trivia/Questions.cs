using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trivia
{
    public class Questions
    {
        private readonly List<QuestionStack> _questionStacks = new List<QuestionStack>();

        public static readonly LinkedList<Questions> PopStack = new LinkedList<Questions>();
        public static readonly LinkedList<Questions> SciencesStack = new LinkedList<Questions>();
        public static readonly LinkedList<Questions> SportsStack = new LinkedList<Questions>();
        public static readonly LinkedList<Questions> RockStack = new LinkedList<Questions>();

        public void AddStacks(string[] categories)
        {
            foreach (String category in categories)
            {
                var questionStack = new QuestionStack(category);
                _questionStacks.Add(questionStack);
            }

            foreach (var questionStack in _questionStacks)
            {
                for (var i = 0; i < 50; i++)
                {
                    questionStack.AddQuestion(questionStack._category + " Question " + i, "");
                }
            }
        }
    }
}
