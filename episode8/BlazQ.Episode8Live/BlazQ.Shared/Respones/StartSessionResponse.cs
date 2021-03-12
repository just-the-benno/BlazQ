using System;
using System.Collections.Generic;

namespace BlazQ.Shared
{
    public class StartSessionResponse
    {
        public Guid SessionId {get; set;}
        public List<ServerSidePlayerOverview> Players { get; set; }
        public List<ServerSideQuestionOverview> Questions {get; set;}
    }
}