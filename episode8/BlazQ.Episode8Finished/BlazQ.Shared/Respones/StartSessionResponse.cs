using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazQ.Shared
{
    public class StartSessionResponse
    {
        public List<ServerSidePlayerOverview> PlayerInSession { get; set; }
        public List<QuestionResponse> Questions { get; set; }
    }
}
