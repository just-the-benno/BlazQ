using System;
using System.Collections.Generic;
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

        public PlayerViewModel Player {get; init; }

        public Int32 QuestionIndex { get; private set; } = 0;

        public GameSession(PlayerViewModel player)
        {
            Player = player;
        }

        public QuestionViewModel GetCurrentQuestion()
        {
            return Questions[QuestionIndex];
        }

        public Boolean MoveToNextQuestion()
        {
            if(QuestionIndex < Questions.Count - 1)
            {
                QuestionIndex = QuestionIndex + 1;
                return true;
            }

            return false;
        }

        public void Restart()
        {
            QuestionIndex = 0;
        }
    }
}