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
            new QuestionViewModel { Text = "What number is NOT a Fibonacci number", Options = new List<String> { "1", "2", "8", "20" }, CorrectOptionIndex = 3, Value = 1000 },
            new QuestionViewModel { Text = "What was the name of the supernatural computer in »The hitchhiker's guide to the galaxy«", Options = new List<String> { "Who cares", "Think deep", "Deep Thought", "42" }, CorrectOptionIndex = 2, Value = 2000 },
            new QuestionViewModel { Text = "According to Scott Pilgrim, how many vegan law violations can you commit without losing your vegan superpowers?", Options = new List<String> { "4", "3", "2", "1" }, CorrectOptionIndex = 1, Value = 2000 },
            new QuestionViewModel { Text = "You know what? (F is for Familiy)", Options = new List<String> { "You know what?", "You know what? You know what?", "You know what? You know what? You know what? ", "You know what? You know what? You know what? You know what?" }, CorrectOptionIndex = 1, Value = 3000  },
        };

        public List<Player> Players { get; init; } = new List<Player>();
        private List<Int32> _usedOptions = new List<int>();
        public List<GameSessionReportViewModel> Reports { get; private set; }

        public GameSession(Int32 questionIndex)
        {
            this.QuestionIndex = questionIndex;

        }
        public Int32 QuestionIndex { get; private set; } = 0;

        private DateTime _started;


        public GameSession(List<Player> players)
        {
            Players = new List<Player>(players);
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

                for (Int32 playerIndex = 0; playerIndex < Players.Count; playerIndex++)
                {
                    Player player = Players[playerIndex];

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

            QuestionViewModel question = GetCurrentQuestion();
            Boolean isCorrect = answerIndex == question.CorrectOptionIndex;

            Player player = Players[playerIndex];
            player.SetAnswers(QuestionIndex, question.Value, isCorrect);

            return isCorrect;
        }

        public void Restart()
        {
            QuestionIndex = 0;
            foreach (var item in Players)
            {
                item.Reset();
            }
        }

        public Boolean AllPlayersHaveAnswered()
        {
            foreach (var item in Players)
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
            Player player = Players[playerIndex];
            return player.HasAnswered(QuestionIndex);
        }

        public Boolean OptionHasAlreadyBeenChoosen(Int32 optionIndex)
        {
            Boolean isUsed = _usedOptions.Contains(optionIndex);
            return isUsed;
        }

        public void PlayerActivatedNailJoker(Int32 playerIndex)
        {
            Player player = Players[playerIndex];
            player.ActivateNailJoker();
        }

        public void NailJokerLinked(Int32 nailerIndex, Int32 naileeIndex)
        {
            Player nailer = Players[nailerIndex];
            Player nailee = Players[naileeIndex];
            nailee.LinkNailer(nailer);
        }

        public Int32 TotalReliableWisdomJokerRequested(Int32 playerIndex)
        {
            Random random = new Random();
            Int32 optionToChoose = -1;

            if (IsOnlyOneOptionLeft() == true)
            {
                optionToChoose = GetCurrentQuestion().CorrectOptionIndex;
            }
            else
            {
                Int32 correctOptionIndex = GetCurrentQuestion().CorrectOptionIndex;
                Boolean willBeRightAnswer = random.NextDouble() >= 0.3;

                if (willBeRightAnswer == false)
                {
                    for (int i = 0; i < GetCurrentQuestion().Options.Count; i++)
                    {
                        if (i == correctOptionIndex)
                        {
                            continue;
                        }

                        if (OptionHasAlreadyBeenChoosen(i) == true)
                        {
                            continue;
                        }

                        optionToChoose = i;
                        break;
                    }
                }
                else
                {
                    optionToChoose = correctOptionIndex;
                }
            }

            Player player = Players[playerIndex];
            player.TotalReliableWisdomJokerHasBeenUsed();

            return optionToChoose;
        }

        public Boolean IsOnlyOneOptionLeft()
        {
            Boolean result = (GetCurrentQuestion().Options.Count - _usedOptions.Count) == 1;
            return result;
        }

        public Boolean PlayerCanUseTotalReliableWisdomJoker(Int32 playerIndex)
        {
            return Players[playerIndex].TotalReliableWisdomJokerIsUsed == false;
        }

        public Boolean PlayerCanUseNailJoker(Int32 playerIndex)
        {
            return Players[playerIndex].NailJokerIsUsed == false;
        }

        public Boolean IsLastQuestion() => QuestionIndex == Questions.Count - 1;
    }
}