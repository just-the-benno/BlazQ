using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazQ.Episode2.Game
{
    public class Question
    {
        public String Text { get; set; }
        public List<String> Options { get; set; }
        public Int32 CorrectOptionIndex { get; set; }
    }
}
