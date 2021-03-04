using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazQ.MultiplayerServer.Domain
{
    public class Lobby
    {
        public List<PlayerServerSide> Players { get; init; }
        public Guid Id { get; init; }

        public Lobby(PlayerServerSide player)
        {
            Players = new List<PlayerServerSide> { player };
            Id = Guid.NewGuid();
        }

        internal void Join(PlayerServerSide player)
        {
            if (Players.Contains(player) == true)
            {
                return;
            }

            Players.Add(player);
        }

        internal void Leave(PlayerServerSide player)
        {
            if (Players.Contains(player) == false)
            {
                return;
            }

            Players.Remove(player);

            if (Players.Count == 0)
            {
                Shutdown();
            }
        }

        private void Shutdown()
        {

        }
    }
}
