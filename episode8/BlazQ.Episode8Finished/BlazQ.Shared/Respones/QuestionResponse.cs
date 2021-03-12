using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazQ.Shared
{
    public class QuestionResponse
    {
        public String Text { get; set; }
        public List<String> Options { get; set; }
        public Int32 CorrectOptionIndex { get; set; }
        public Int32 Value { get; set; }
    }
}
