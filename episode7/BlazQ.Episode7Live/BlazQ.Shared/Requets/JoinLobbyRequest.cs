using System;

namespace BlazQ.Shared.Requets
{
    public class JoinLobbyRequest
    {
        public Guid HostId { get; set; }
        public Guid JoineeId { get; set; }
    }
}