using BlazQ.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazQ.Shared
{
    public interface ILobbyClient
    {
        public Task NewPlayer(ServerSidePlayerOverview newPlayer);

        public Task PlayerJoinedLobby(ServerSidePlayerOverview newPlayer);
        public Task PlayerLeavedLobby(Guid playerId);
        public Task StartSession(StartSessionResponse response);
        public Task KeyPressedReceived(KeyPressedResponse keyPressedResponse);
    }
}
