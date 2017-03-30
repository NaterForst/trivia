using System;
using System.Collections.Generic;
using System.Linq;

namespace Trivia
{
    public class Game
    {
        private readonly List<Player> _players = new List<Player>();
        private readonly Dictionary<int, string> _categories = new Dictionary<int, string>() {{0, "Pop"}, {1, "Science"}, {2, "Sports"}, {3, "Rock"}};

        readonly LinkedList<string> _popQuestions = new LinkedList<string>();
        readonly LinkedList<string> _scienceQuestions = new LinkedList<string>();
        readonly LinkedList<string> _sportsQuestions = new LinkedList<string>();
        readonly LinkedList<string> _rockQuestions = new LinkedList<string>();

        private int _currentPlayer = 0;
        private bool _isGettingOutOfPenaltyBox;

        public Game()
        {
            for (var i = 0; i < 50; i++)
            {
                _popQuestions.AddLast("Pop Question " + i);
                _scienceQuestions.AddLast(("Science Question " + i));
                _sportsQuestions.AddLast(("Sports Question " + i));
                _rockQuestions.AddLast(CreateRockQuestion(i));
            }
        }

        public string CreateRockQuestion(int index)
        {
            return "Rock Question " + index;
        }

        public bool IsPlayable()
        {
            return (HowManyPlayers() >= 2);
        }

        public bool Add(string playerName)
        {
            _players.Add(new Player(playerName));

            Console.WriteLine(playerName + " was added");
            Console.WriteLine("They are player number " + _players.Count);
            return true;
        }

        public int HowManyPlayers()
        {
            return _players.Count;
        }

        public void Roll(int roll)
        {
            Console.WriteLine(_players[_currentPlayer].Name + " is the current player");
            Console.WriteLine("They have rolled a " + roll);

            if (_players[_currentPlayer].InPenaltyBox)
            {
                if (roll % 2 != 0)
                {
                    _isGettingOutOfPenaltyBox = true;

                    Console.WriteLine(_players[_currentPlayer].Name + " is getting out of the penalty box");
                    _players[_currentPlayer].Move(roll);

                    Console.WriteLine(_players[_currentPlayer].Name
                            + "'s new location is "
                            + _players[_currentPlayer].Place);
                    Console.WriteLine("The category is " + CurrentCategory());
                    AskQuestion();
                }
                else
                {
                    Console.WriteLine(_players[_currentPlayer].Name + " is not getting out of the penalty box");
                    _isGettingOutOfPenaltyBox = false;
                }

            }
            else
            {
                _players[_currentPlayer].Move(roll);

                Console.WriteLine(_players[_currentPlayer].Name
                        + "'s new location is "
                        + _players[_currentPlayer].Place);
                Console.WriteLine("The category is " + CurrentCategory());
                AskQuestion();
            }

        }

        private void AskQuestion()
        {
            switch (CurrentCategory())
            {
                case "Pop":
                    Console.WriteLine(_popQuestions.First());
                    _popQuestions.RemoveFirst();
                    break;
            }
            switch (CurrentCategory())
            {
                case "Science":
                    Console.WriteLine(_scienceQuestions.First());
                    _scienceQuestions.RemoveFirst();
                    break;
            }
            switch (CurrentCategory())
            {
                case "Sports":
                    Console.WriteLine(_sportsQuestions.First());
                    _sportsQuestions.RemoveFirst();
                    break;
            }
            switch (CurrentCategory())
            {
                case "Rock":
                    Console.WriteLine(_rockQuestions.First());
                    _rockQuestions.RemoveFirst();
                    break;
            }
        }


        private string CurrentCategory()
        {
            return _categories[_players[_currentPlayer].Place % 4];
        }

        public bool WasCorrectlyAnswered()
        {
            bool winner;
            if (_players[_currentPlayer].InPenaltyBox)
            {
                if (_isGettingOutOfPenaltyBox)
                {
                    Console.WriteLine("Answer was correct!!!!");
                    _players[_currentPlayer].WinAGoldCoin();

                    winner = DidPlayerWin();
                    ChangePlayer();

                    return winner;
                }

                ChangePlayer();
                return true;
            }

            Console.WriteLine("Answer was corrent!!!!");
            _players[_currentPlayer].WinAGoldCoin();

            winner = DidPlayerWin();
            ChangePlayer();

            return winner;
        }

        private void ChangePlayer()
        {
            _currentPlayer++;
            if (_currentPlayer == _players.Count) _currentPlayer = 0;
        }

        public bool WrongAnswer()
        {
            Console.WriteLine("Question was incorrectly answered");
            Console.WriteLine(_players[_currentPlayer].Name + " was sent to the penalty box");
            _players[_currentPlayer].GoToPenaltyBox();

            ChangePlayer();
            return true;
        }


        private bool DidPlayerWin()
        {
            return _players[_currentPlayer].GoldCoins != 6;
        }
    }
}
