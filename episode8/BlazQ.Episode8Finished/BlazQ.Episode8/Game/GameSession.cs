using System;
using System.Collections.Generic;
using System.Linq;
using BlazQ.Player;
using BlazQ.Shared;

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

        public List<QuestionResponse> Questions { get; init; }

        public Player FirstPlayer => Players[0];
        public List<Player> Players { get; init; }
        private List<Int32> _usedOptions = new List<int>();
        public List<GameSessionReportViewModel> Reports { get; private set; }

        public Int32 QuestionIndex { get; private set; } = 0;

        private DateTime _started;

        public Guid LobbyId { get; init; }
        public Guid PlayerId { get; init; }

        public GameSession(Player player)
        {
            Players = new List<Player> { player };
        }

        public GameSession(List<Player> players,
            List<QuestionResponse> questions,
            Guid sessionId,
            Guid playerId
            )
        {
            Players = players;
            _started = DateTime.Now;

            Questions = questions;
            PlayerId = playerId;
            LobbyId = sessionId;
        }

        public QuestionResponse GetCurrentQuestion()
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

            QuestionResponse currentQuestions = GetCurrentQuestion();
            Boolean isCorrect = answerIndex == currentQuestions.CorrectOptionIndex;

            Player player = Players[playerIndex];
            player.SetAnswers(QuestionIndex, currentQuestions.Value, isCorrect);

            return isCorrect;
        }

        public void Restart()
        {
            QuestionIndex = 0;
            foreach (var player in Players)
            {
                player.Reset();
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

        private Boolean OnlyOneOptionIsLeft()
        {
            Int32 optionsAmount = GetCurrentQuestion().Options.Count;

            foreach (var player in Players)
            {
                if (player.HasAnswered(QuestionIndex) == true)
                {
                    optionsAmount -= 1;
                }
            }

            return optionsAmount == 1;
        }

        public Int32 GetAnswerFromTotalReliableWisdomJoker(Int32 playerIndex)
        {
            Player player = Players[playerIndex];
            player.TotalReliableWisdomJokerUsed();

            Int32 choosenOptionIndex = -1;
            if (OnlyOneOptionIsLeft() == true)
            {
                choosenOptionIndex = GetCurrentQuestion().CorrectOptionIndex;
            }
            else
            {
                Random random = new Random();
                Boolean shouldBeCorrectAnswer = random.NextDouble() <= 0.7;
                if (shouldBeCorrectAnswer == true)
                {
                    choosenOptionIndex = GetCurrentQuestion().CorrectOptionIndex;
                }
                else
                {
                    for (int i = 0; i < GetCurrentQuestion().Options.Count; i++)
                    {
                        if (OptionHasAlreadyBeenChoosen(i) == true)
                        {
                            continue;
                        }

                        if (i == GetCurrentQuestion().CorrectOptionIndex)
                        {
                            continue;
                        }

                        choosenOptionIndex = i;
                        break;
                    }
                }
            }

            return choosenOptionIndex;

        }

        public Boolean PlayerHasUsedTotalReliableWisdomJoker(Int32 playerIndex)
        {
            Player player = Players[playerIndex];
            return player.HasUsedTotalReliableWisdomJoker;
        }
        public Boolean PlayerHasUsedNailJoker(Int32 playerIndex)
        {
            Player player = Players[playerIndex];
            return player.HasUsedNailJoker;
        }

        public void PlayerReqiuestedNailJoker(Int32 playerIndex)
        {
            Player player = Players[playerIndex];
            player.NailJokerRequested();
        }

        public void LinkNailerToNailee(Int32 nailerPlayerIndex, Int32 naileePlayerIndex)
        {
            Player nailer = Players[nailerPlayerIndex];
            Player nailee = Players[naileePlayerIndex];

            nailee.LinkToNailer(nailer);
        }

        public Boolean IsCurrentPlayer(Int32 playerIndex)
        {
            Player player = Players[playerIndex];
            return player.Id == PlayerId;
        }
    }
}