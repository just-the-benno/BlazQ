using System;
using System.Collections.Generic;
using System.Linq;
using BlazQ.Player;

namespace BlazQ.Game
{
    public class GameSession
    {
        public List<QuestionViewModel> Questions { get; } = new List<QuestionViewModel>
        {
            new QuestionViewModel { Text = "What number is NOT a Fibonacci number", Options = new List<String> { "1", "2", "8", "20" }, CorrectOptionIndex = 3 },
            new QuestionViewModel { Text = "What was the name of the supernatural computer in »The hitchhiker's guide to the galaxy«", Options = new List<String> { "Who cares", "Think deep", "Deep Thought", "42" }, CorrectOptionIndex = 2 },
            new QuestionViewModel { Text = "According to Scott Pilgrim, how many vegan law violations can you commit without losing your vegan superpowers?", Options = new List<String> { "4", "3", "2", "1" }, CorrectOptionIndex = 1 },
            new QuestionViewModel { Text = "You know what? (F is for Familiy)", Options = new List<String> { "You know what?", "You know what? You know what?", "You know what? You know what? You know what? ", "You know what? You know what? You know what? You know what?" }, CorrectOptionIndex = 1 },
        };

        public PlayerViewModel Player { get; init; }

        public GameSessionReportViewModel Report { get; private set; }

        private Dictionary<Int32, Boolean> _answerMapper = new();

        public Int32 QuestionIndex { get; private set; } = 0;

        private DateTime _started;

        private void InitAnswerMapper()
        {
            _answerMapper.Clear();
            for (int i = 0; i < Questions.Count; i++)
            {
                _answerMapper.Add(i, false);
            }
        }
        public GameSession(PlayerViewModel player)
        {
            Player = player;

            _started = DateTime.Now;

            InitAnswerMapper();
        }

        public QuestionViewModel GetCurrentQuestion()
        {
            return Questions[QuestionIndex];
        }

        public Boolean MoveToNextQuestion()
        {
            if (QuestionIndex < Questions.Count - 1)
            {
                QuestionIndex = QuestionIndex + 1;
                return true;
            }

            if (Report == null)
            {
                Report = new GameSessionReportViewModel
                {
                    TotalQuestions = Questions.Count,
                    CorrectAnswers = _answerMapper.Count(x => x.Value == true),
                    WrongAnswers = _answerMapper.Count(x => x.Value == false),
                    Duration = DateTime.Now - _started,
                };
            }

            return false;
        }

        public Boolean AnswerWasCorrect(Int32 questionIndex)
        {
            Boolean hasBeenAnsweredCorrectly = _answerMapper[questionIndex];
            return hasBeenAnsweredCorrectly;
        }

        public void SubmitAnswer(Int32 answerIndex)
        {
            Boolean isCorrect = answerIndex == GetCurrentQuestion().CorrectOptionIndex;
            _answerMapper[QuestionIndex] = isCorrect;
        }

        public void Restart()
        {
            QuestionIndex = 0;
            InitAnswerMapper();
        }
    }
}