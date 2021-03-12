using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazQ.Shared
{
    public class ServerSideJoinLobbyRequest
    {
        public Guid PlayerId { get; set; }
        public Guid HostId { get; set; }
    }
}
