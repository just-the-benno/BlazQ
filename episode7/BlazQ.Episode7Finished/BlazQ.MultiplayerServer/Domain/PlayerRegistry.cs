using BlazQ.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazQ.MultiplayerServer.Domain
{
    public class PlayerRegistry
    {
        private Dictionary<Guid, PlayerServerSide> _players = new();

        public PlayerRegistry()
        {

        }

        public void AddPlayer(Guid playerId, PlayerServerSide player)
        {
            if (_players.ContainsKey(playerId) == false)
            {
                _players.Add(playerId, player);
            }
        }

        public void RemovePlayer(Guid playerId)
        {
            if (_players.ContainsKey(playerId) == false)
            {
                return;
            }

            PlayerServerSide player = _players[playerId];
            player.LeaveLobby();

            _players.Remove(playerId);
        }

        public Boolean JoinLobby(Guid hostPlayerId, Guid joineePlayerId)
        {
            if (_players.ContainsKey(hostPlayerId) == false || _players.ContainsKey(joineePlayerId) == false)
            {
                return false;
            }

            var joinee = _players[joineePlayerId];
            var host = _players[hostPlayerId];

            joinee.JoinLobby(host);
            return true;
        }

        public List<ServerSidePlayerOverview> GetAllPlayers()
        {
            return _players.Select(x => new ServerSidePlayerOverview { Name = x.Value.Name, AvatarUrl = x.Value.AvatarUrl, Id = x.Key }).ToList();
        }

        public Boolean LeaveLobby(Guid playerId)
        {
            if (_players.ContainsKey(playerId) == false)
            {
                return false;
            }

            var player = _players[playerId];
            player.LeaveLobby();

            return true;
        }

        internal Guid GetLobbyIdByPlayerId(Guid playerId)
        {
            PlayerServerSide player = GetPlayerById(playerId);
            return player.Lobby.Id;
        }

        internal int GetPlayerAmountForLobby(Guid playerId)
        {
            if(_players.ContainsKey(playerId) == false)
            {
                return -1;
            }

            PlayerServerSide player = GetPlayerById(playerId);
            return player.Lobby.Players.Count;
        }

        internal PlayerServerSide GetPlayerById(Guid playerId) => _players[playerId];
    }
}
