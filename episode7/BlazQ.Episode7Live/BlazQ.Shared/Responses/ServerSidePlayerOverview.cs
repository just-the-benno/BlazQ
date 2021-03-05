using System;

namespace BlazQ.Shared.Responses
{
    public class ServerSidePlayerOverview
    {
        public Guid Id {get; set;}
        public String Name {get; set;}
        public String AvatarUrl {get; set;}
    }
}