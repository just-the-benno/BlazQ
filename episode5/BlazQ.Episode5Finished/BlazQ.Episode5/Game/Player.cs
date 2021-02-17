using System;
using System.Collections.Generic;
using System.Linq;
using BlazQ.Player;

namespace BlazQ.Game
{
    public class Player
    {
        public String Name { get; init; }
        public String AvatarUrl { get; init; }

        public Int32 Points {get; private set;} = 0;

        public Int32 Multiplicator {get; private set; } = 1;

        private Dictionary<Int32, Boolean> _answers = new();

        public Boolean NailJokerIsActive {get; private set;}
        public Boolean NailJokerIsUsed { get; private set;}

        public Boolean TotalReliableWisdomJokerIsUsed {get; private set;}

        public Player(CreatePlayerViewModel vm)
        {
            Name = vm.Name;
            AvatarUrl = vm.AvatarUrl;
        }

        public Boolean HasAnswered(Int32 questionIndex)
        {
            Boolean result = _answers.ContainsKey(questionIndex);
            return result;
        }

        internal void SetAnswers(int questionIndex, Int32 questionValue, bool isCorrect)
        {
            _answers.Add(questionIndex, isCorrect);
            Int32 questionPoints = Multiplicator * questionValue;
            if(isCorrect == true)
            {
                Points +=  questionPoints;
                Multiplicator += 1;
                if(_nailer != null)
                {
                    _nailer.NailJokerHasFailed(questionPoints);
                    _nailer = null;
                }
            }
            else
            {
                Points -= questionPoints;
                Multiplicator = 1;
                 if(_nailer != null)
                {
                    _nailer.NailJokerWasSuccessful();
                    _nailer = null;
                }
            }
        }

        private void NailJokerHasFailed(Int32 pointsToLoose)
        {
            Points -= pointsToLoose;
            Multiplicator = 1;
            NailJokerIsUsed = true;
            NailJokerIsActive = false;
        }

        private void NailJokerWasSuccessful()
        {
            NailJokerIsActive = false;
            NailJokerIsUsed = true;
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

        internal void ActivateNailJoker()
        {
            NailJokerIsActive = true;
        }

        private Player _nailer;

        internal void LinkNailer(Player nailer)
        {
            _nailer = nailer;
        }

        internal void TotalReliableWisdomJokerHasBeenUsed()
        {
            TotalReliableWisdomJokerIsUsed = true;
        }

        internal void Reset()
        {
            Points = 0;
            Multiplicator = 1;
            _answers.Clear();
            NailJokerIsActive = false;
            NailJokerIsUsed = false;

            TotalReliableWisdomJokerIsUsed = false;
        }
    }
}