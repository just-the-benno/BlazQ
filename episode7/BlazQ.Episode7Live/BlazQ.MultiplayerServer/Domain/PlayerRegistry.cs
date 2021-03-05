using System;
using System.Collections.Generic;

namespace BlazQ.MultiplayerServer.Domain
{
    public class PlayerRegistry
    {
        private Dictionary<Guid, ServerSidePlayer> _activePlayers = new();

        public void AddPlayer(ServerSidePlayer player)
        {
            if (_activePlayers.ContainsKey(player.Id) == true)
            {
                return;
            }

            _activePlayers.Add(player.Id, player);
        }

        public IEnumerable<ServerSidePlayer> GetAllPlayers() => _activePlayers.Values;

        internal Guid JoinLobby(Guid hostId, Guid joineeId)
        {
            if (
                _activePlayers.ContainsKey(hostId) == false ||
                _activePlayers.ContainsKey(joineeId) == false)
            {
                return Guid.Empty;
            }

            ServerSidePlayer host = _activePlayers[hostId];
            ServerSidePlayer joinee = _activePlayers[joineeId];

            host.Join(joinee);

            return host.Lobby.Id;
        }

        internal List<ServerSidePlayer> GetLobbyMembers(Guid playerId)
        {
            if (_activePlayers.ContainsKey(playerId) == false)
            {
                return new List<ServerSidePlayer>();
            }

            ServerSidePlayer player = _activePlayers[playerId];
            return player.Lobby.Members;
        }

        internal ServerSidePlayer GetPlayerById(Guid joineeId)
        {
            if(_activePlayers.ContainsKey(joineeId) == true)
            {
                return _activePlayers[joineeId];
            }

            return null;
        }
    }
}