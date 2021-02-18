using System;
using System.Collections.Generic;
using System.Linq;
using BlazQ.Player;

namespace BlazQ.Game
{
    public class GameSession
    {
        public static Dictionary<Int32, String> HotKeys = new Dictionary<int, string>
        {
            { 0, "a" },
            { 1, "f" },
            { 2, "u" },
            { 3, "l" },
        };

        public List<QuestionViewModel> Questions { get; } = new List<QuestionViewModel>
        {
            new QuestionViewModel { Text = "What number is NOT a Fibonacci number", Options = new List<String> { "1", "2", "8", "20" }, CorrectOptionIndex = 3 },
            new QuestionViewModel { Text = "What was the name of the supernatural computer in »The hitchhiker's guide to the galaxy«", Options = new List<String> { "Who cares", "Think deep", "Deep Thought", "42" }, CorrectOptionIndex = 2 },
            new QuestionViewModel { Text = "According to Scott Pilgrim, how many vegan law violations can you commit without losing your vegan superpowers?", Options = new List<String> { "4", "3", "2", "1" }, CorrectOptionIndex = 1 },
            new QuestionViewModel { Text = "You know what? (F is for Familiy)", Options = new List<String> { "You know what?", "You know what? You know what?", "You know what? You know what? You know what? ", "You know what? You know what? You know what? You know what?" }, CorrectOptionIndex = 1 },
        };

        public PlayerViewModel Player { get; init; }

        public List<PlayerViewModel> Players { get; init; }

        private List<Player> _players = new List<Player>();
        private List<Int32> _usedOptions = new List<int>();
        public List<GameSessionReportViewModel> Reports { get; private set; }

        public Int32 QuestionIndex { get; private set; } = 0;

        private DateTime _started;


        public GameSession(List<PlayerViewModel> players)
        {
            Players = players;

            foreach (var item in players)
            {
                _players.Add(new Game.Player());
            }

            _started = DateTime.Now;
        }

        public QuestionViewModel GetCurrentQuestion()
        {
            return Questions[QuestionIndex];
        }

        public Boolean MoveToNextQuestion()
        {
            _usedOptions.Clear();

            if (QuestionIndex < Questions.Count - 1)
            {
                QuestionIndex = QuestionIndex + 1;
                return true;
            }

            if (Reports == null)
            {
                Reports = new List<GameSessionReportViewModel>();

                for (Int32 playerIndex = 0; playerIndex < _players.Count; playerIndex++)
                {
                    Player player = _players[playerIndex];

                    GameSessionReportViewModel report = new GameSessionReportViewModel
                    {
                        TotalQuestions = Questions.Count,
                        CorrectAnswers = player.CountCorrectAnswers(),
                        WrongAnswers = player.CountWrongAnswers(),
                        Player = Players[playerIndex],
                    };

                    Reports.Add(report);
                };
            }

            return false;
        }

        public Boolean SubmitAnswer(Int32 answerIndex, Int32 playerIndex)
        {
            _usedOptions.Add(answerIndex);

            Boolean isCorrect = answerIndex == GetCurrentQuestion().CorrectOptionIndex;

            Player player = _players[playerIndex];
            player.SetAnswers(QuestionIndex, isCorrect);

            return isCorrect;
        }

        public void Restart()
        {
            QuestionIndex = 0;
        }

        public Boolean AllPlayersHaveAnswered()
        {
            foreach (var item in _players)
            {
                if (item.HasAnswered(QuestionIndex) == false)
                {
                    return false;
                }
            }

            return true;
        }

        public Boolean PlayerHasAlreadyAnswerd(Int32 playerIndex)
        {
            Player player = _players[playerIndex];
            return player.HasAnswered(QuestionIndex);
        }



        public Boolean OptionHasAlreadyBeenChoosen(Int32 optionIndex)
        {
            Boolean isUsed = _usedOptions.Contains(optionIndex);
            return isUsed;
        }
    }
}