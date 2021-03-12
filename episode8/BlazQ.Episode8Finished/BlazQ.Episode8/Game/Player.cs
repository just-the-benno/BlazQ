using System;
using System.Collections.Generic;
using System.Linq;

namespace BlazQ.Game
{
    public class Player
    {
        private Dictionary<Int32, Boolean> _answers = new();

        public String Name { get; init; }
        public String AvatarUrl { get; init; }
        public Guid Id { get; init; }

        public Int32 Points { get; private set; } = 0;

        public Int32 Multiplier { get; private set; } = 1;
        public Boolean HasUsedTotalReliableWisdomJoker { get; private set; }

        public Boolean HasUsedNailJoker { get; private set; }

        public Boolean NailJokerIsInUse { get; private set; }


        private Player _nailer;


        public Player(String name, String avatarUrl) : this(name, avatarUrl, Guid.NewGuid())
        {
        }

        public Player(String name, String avatarUrl, Guid id)
        {
            this.Name = name;
            this.AvatarUrl = avatarUrl;
            Id = id;
        }

        public Boolean HasAnswered(Int32 questionIndex)
        {
            Boolean result = _answers.ContainsKey(questionIndex);
            return result;
        }

        internal void SetAnswers(int questionIndex, Int32 points, bool isCorrect)
        {
            _answers.Add(questionIndex, isCorrect);
            Int32 score = Multiplier * points;
            if (isCorrect == true)
            {
                Points += score;
                Multiplier += 1;
                if (_nailer != null)
                {
                    _nailer.NailJokerFailed(score);
                    _nailer = null;
                }
            }
            else
            {
                Points -= score;
                Multiplier = 1;
                if (_nailer != null)
                {
                    _nailer.NailJokerSucceeded();
                    _nailer = null;
                }
            }
        }

        private void NailJokerExecuted()
        {
            NailJokerIsInUse = true;
            HasUsedNailJoker = true;
        }

        private void NailJokerSucceeded()
        {
            NailJokerExecuted();
        }

        private void NailJokerFailed(int score)
        {
            Multiplier = 1;
            Points -= score;
            NailJokerExecuted();
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

        public void TotalReliableWisdomJokerUsed()
        {
            HasUsedTotalReliableWisdomJoker = true;
        }

        public void NailJokerRequested()
        {
            NailJokerIsInUse = true;
        }

        public void LinkToNailer(Player nailer)
        {
            _nailer = nailer;
        }

        internal void Reset()
        {
            _answers.Clear();
            Points = 0;
            Multiplier = 1;
            NailJokerIsInUse = false;
            HasUsedNailJoker = false;
            HasUsedTotalReliableWisdomJoker = false;
        }
    }
}