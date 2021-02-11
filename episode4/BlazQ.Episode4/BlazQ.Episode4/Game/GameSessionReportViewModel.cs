using System;

namespace BlazQ.Game
{
    public class GameSessionReportViewModel
    {
        public Int32 TotalQuestions {get; set;}
        public Int32 CorrectAnswers {get; set; }
        
        public Int32 WrongAnswers { get; set;}

        public Double PercentageOfCorrectAnswer => 
        Math.Round( 100.0 * CorrectAnswers / TotalQuestions,2);
        
        public TimeSpan Duration {get; set;}

    }
}