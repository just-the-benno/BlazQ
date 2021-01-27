using BlazQ.Episode2.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazQ.Episode2.Game
{
    public class GameSession
    {
        public List<Question> Questions { get; } = new List<Question>
        {
            new Question { Text = "What number is NOT a Fibonacci number", Options = new List<String> { "1", "2", "8", "20" }, CorrectOptionIndex = 3 },
            new Question { Text = "What was the name of the supernatural computer in »The hitchhiker's guide to the galaxy«", Options = new List<String> { "Who cares", "Think deep", "Deep Thought", "42" }, CorrectOptionIndex = 2 },
            new Question { Text = "According to Scott Pilgrim, how many vegan law violations can you commit without losing your vegan superpowers?", Options = new List<String> { "4", "3", "2", "1" }, CorrectOptionIndex = 1 },
            new Question { Text = "You know what? (F is for Familiy)", Options = new List<String> { "You know what?", "You know what? You know what?", "You know what? You know what? You know what? ", "You know what? You know what? You know what? You know what?" }, CorrectOptionIndex = 1 },
        };

        public PlayerViewModel Player { get; init; }
        public Int32 QuestionIndex { get; private set; }

        public GameSession(PlayerViewModel player)
        {
            Player = player;
        }

        public Boolean AnswerQuestion(Int32 optionIndex)
        {
            Question currentQuestions = Questions[QuestionIndex];

            Boolean isRightAnswer = currentQuestions.CorrectOptionIndex == optionIndex;

            return isRightAnswer;
        }

        public Question GetCurrentQuestion()
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
