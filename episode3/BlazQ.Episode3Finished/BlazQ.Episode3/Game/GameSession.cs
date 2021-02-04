using System;
using System.Collections.Generic;
using BlazQ.Player;
using System.Linq;

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

        private Dictionary<Int32, Boolean> _answerTracker = new Dictionary<int, bool>();

        public PlayerViewModel Player { get; init; }

        public GameSessionResultViewModel Report { get; private set; }

        private DateTime _start;

        public Int32 QuestionIndex { get; private set; } = 0;

        public GameSession(PlayerViewModel player)
        {
            Player = player;
            InitAnswerTracker();

            _start = DateTime.Now;
        }

        private void InitAnswerTracker()
        {
            _answerTracker.Clear();
            for (int i = 0; i < Questions.Count; i++)
            {
                _answerTracker.Add(i, false);
            }
        }

        public void SubmitAnswer(Int32 choosenIndex)
        {
            Boolean isCorrectAnswer = choosenIndex == GetCurrentQuestion().CorrectOptionIndex;
            _answerTracker[QuestionIndex] = isCorrectAnswer;
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
                Report = new GameSessionResultViewModel
                {
                    TotalQuestions = Questions.Count,
                    CorrectAnswers = _answerTracker.Count(x => x.Value == true),
                    WrongAnswers = _answerTracker.Count(x => x.Value == false),
                    Duration = DateTime.Now - _start,
                };
            }

            return false;
        }

        public void Restart()
        {
            QuestionIndex = 0;
            InitAnswerTracker();
        }

        public Boolean AnswerWasCorrect(Int32 questionIndex)
        {
            return _answerTracker[questionIndex];
        }

    }
}