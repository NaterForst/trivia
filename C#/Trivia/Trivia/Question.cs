using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trivia
{
    public class Question
    {
        private string _question;
        private string _answer;

        public Question(string quest, string resp)
        {
            _question = quest;
            _answer = resp;
        }
    }
}
