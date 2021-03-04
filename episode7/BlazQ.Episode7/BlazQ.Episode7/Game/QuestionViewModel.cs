using System;
using System.Collections.Generic;

namespace BlazQ.Game
{
    public class QuestionViewModel
    {
        public String Text { get; set; }
        public List<String> Options { get; set; }
        public Int32 CorrectOptionIndex { get; set; }
        public Int32 Value { get; set; }

    }
}