using System;
using System.Collections.Generic;
using System.Linq;
using BlazQ.Player;

namespace BlazQ.Game
{
    public class GameSession
    {
        public static Dictionary<Int32, String> PlayerKeys { get; } = new Dictionary<int, String>
        {
            { 0, "a" },
            { 1, "f" },
            { 2, "u" },
            { 3, "l" },
        };

        public List<QuestionViewModel> Questions { get; } = new List<QuestionViewModel>
        {
            new QuestionViewModel { Text = "What number is NOT a Fibonacci number?", Options = new List<String> { "1", "2", "8", "20" }, CorrectOptionIndex = 3 },
            new QuestionViewModel { Text = "What was the name of the supernatural computer in »The hitchhiker's guide to the galaxy«?", Options = new List<String> { "Who cares", "Think deep", "Deep Thought", "42" }, CorrectOptionIndex = 2 },
            new QuestionViewModel { Text = "According to Scott Pilgrim, how many vegan law violations can you commit without losing your vegan superpowers?", Options = new List<String> { "4", "3", "2", "1" }, CorrectOptionIndex = 1 },
            new QuestionViewModel { Text = "You know what? (F is for Familiy)", Options = new List<String> { "You know what?", "You know what? You know what?", "You know what? You know what? You know what? ", "You know what? You know what? You know what? You know what?" }, CorrectOptionIndex = 1 },
        };

        public List<PlayerViewModel> Players { get; init; }

        public List<Player> _internalPlayers = new List<Player>();

        public List<GameSessionReportViewModel> Reports { get; private set; }

        public Int32 QuestionIndex { get; private set; } = 0;

        private DateTime _started;


        public GameSession(List<PlayerViewModel> players)
        {
            Players = players;
            _started = DateTime.Now;

            _internalPlayers = new List<Player>();
            foreach (var item in players)
            {
                _internalPlayers.Add(new Player(item));
            }
        }

        public QuestionViewModel GetCurrentQuestion()
        {
            return Questions[QuestionIndex];
        }

        public Boolean MoveToNextQuestion()
        {
            if (QuestionIndex < Questions.Count - 1)
            {
                foreach (var item in _internalPlayers)
                {
                    item.FinishQuestions(QuestionIndex);
                }

                QuestionIndex = QuestionIndex + 1;
                return true;
            }

            if (Reports == null)
            {
                Reports = new();
                for (int i = 0; i < Players.Count; i++)
                {
                    var player = Players[i];
                    GameSessionReportViewModel report = new GameSessionReportViewModel
                    {
                        TotalQuestions = Questions.Count,
                        CorrectAnswers = _internalPlayers[i].CountCorrectAnswers(),
                        WrongAnswers = _internalPlayers[i].CountWrongAnswers(),
                        Duration = DateTime.Now - _started,
                        Player = player,
                    };

                    Reports.Add(report);
                }
            }

            return false;
        }

        public Boolean AnswerWasCorrect(Int32 playerIndex,  Int32 questionIndex)
        {
            return _internalPlayers[playerIndex].AnswerWasCorrect(questionIndex);
        }

        public Boolean SubmitAnswer(Int32 playerIndex, Int32 answerIndex)
        {
            Boolean isCorrect = answerIndex == GetCurrentQuestion().CorrectOptionIndex;
            _internalPlayers[playerIndex].SubmitAnswer(QuestionIndex,isCorrect);
            return isCorrect;
        }

        public Boolean AllPlayersHaveAnswered()
        {
            foreach (var item in _internalPlayers)
            {
                if(item.HasAnswered(QuestionIndex) == false)
                {
                    return false;
                }    
            }

            return true;
        }

        public Boolean PlayerHasAlreadyAnswered(Int32 playerIndex)
        {
            return _internalPlayers[playerIndex].HasAnswered(QuestionIndex);
        }

        public void Restart()
        {
            QuestionIndex = 0;
            foreach (var item in _internalPlayers)
            {
                item.RestAnswers();
            }
        }
       
    }
}