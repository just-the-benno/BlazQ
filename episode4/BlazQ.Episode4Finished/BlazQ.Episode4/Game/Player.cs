using BlazQ.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazQ.Game
{
    public class Player
    {
        public String Name { get; init; }
        private Dictionary<Int32, Boolean> _answers = new Dictionary<int, bool>();

        public Player(PlayerViewModel viewModel)
        {
            Name = viewModel.Name;
        }

        public void SubmitAnswer(Int32 questionIndex, Boolean isCorrect)
        {
            _answers.Add(questionIndex, isCorrect);
        }

        internal void FinishQuestions(int questionIndex)
        {
            if(_answers.ContainsKey(questionIndex) == false)
            {
                _answers.Add(questionIndex, false);
            }
        }

        public Boolean AnswerWasCorrect(Int32 questionIndex)
        {
            Boolean hasBeenAnsweredCorrectly = _answers[questionIndex];
            return hasBeenAnsweredCorrectly;
        }

        public Boolean HasAnswered(int questionIndex)
        {
            return _answers.ContainsKey(questionIndex);
        }

        private Int32 CountAnswers(Boolean rightOrWrong)
        {
            return _answers.Values.Count(x => x == rightOrWrong);

        }

        public int CountWrongAnswers()
        {
            return CountAnswers(false);
        }

        public int CountCorrectAnswers()
        {
            return CountAnswers(true);
        }

        internal void RestAnswers()
        {
            _answers.Clear();
        }
    }
}
