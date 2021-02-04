using System;

namespace BlazQ.Game
{
    public class GameSessionResultViewModel
    {
        public Int32 TotalQuestions { get; set; }
        public Int32 CorrectAnswers { get; set; }
        public Int32 WrongAnswers { get; set; }
        public TimeSpan Duration { get; set;}
        public Double CorrectPercentage => Math.Round( (100.0 * CorrectAnswers)/TotalQuestions,2);
    }
}