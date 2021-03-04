using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazQ.Shared
{
    public class JoinLobbyResponse
    {
        public List<ServerSidePlayerOverview> PlayersInLobby { get; set; }
        public Guid LobbyId { get; set; }
    }
}
