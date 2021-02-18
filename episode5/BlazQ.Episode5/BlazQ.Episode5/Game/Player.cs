using System;
using System.Collections.Generic;
using System.Linq;

namespace BlazQ.Game
{
    public class Player
    {
        private Dictionary<Int32,Boolean> _answers = new();

        public Boolean HasAnswered(Int32 questionIndex)
        {
            Boolean result = _answers.ContainsKey(questionIndex);
            return result;
        }

        internal void SetAnswers(int questionIndex, bool isCorrect)
        {
            _answers.Add(questionIndex,isCorrect);
        }

        private Int32 CountValues(Boolean value)
        {
            Int32 amount = _answers.Values.Count(x => x == value);
            return amount;
        }

        public Int32 CountCorrectAnswers()
        {
            return CountValues(true);
        }

        public Int32 CountWrongAnswers()
        {
            return CountValues(false);
        }
    }
}