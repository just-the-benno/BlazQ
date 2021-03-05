using System;

namespace BlazQ.Shared.Responses
{
    public class AddPlayerResponse
    {
        public Guid PlayerId { get; set; }
        public Guid LobbyId { get; set; }
    }
}