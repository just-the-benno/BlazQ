using System;
using System.Collections.Generic;

namespace BlazQ.Shared.Responses
{
    public class JoinLobbyResponse
    {
        public Guid LobbyId { get; set; }
        public List<ServerSidePlayerOverview> Members { get; set; }
    }
}