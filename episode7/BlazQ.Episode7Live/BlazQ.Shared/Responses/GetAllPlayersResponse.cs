using System.Collections.Generic;

namespace BlazQ.Shared.Responses
{
    public class GetAllPlayersResponse
    {
        public List<ServerSidePlayerOverview> Players {get; set;}
    }
}