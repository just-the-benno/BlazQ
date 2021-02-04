using System;
using System.Collections.Generic;

namespace BlazQ.Episode2.Game
{
    public class QuestionViewModel
    {
        public String Text { get; set; }
        public List<String> Options { get; set; }
        public Int32 CorrectOptionIndex { get; set; }

    }
}