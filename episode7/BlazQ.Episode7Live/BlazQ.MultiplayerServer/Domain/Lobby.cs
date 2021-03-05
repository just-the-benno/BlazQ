using System;
using System.Collections.Generic;

namespace BlazQ.MultiplayerServer.Domain
{
    public class Lobby
    {
        public Guid Id { get; init; } = Guid.NewGuid();

        public List<ServerSidePlayer> Members { get; init; } = new();
        public Lobby(ServerSidePlayer firstMember)
        {
            Members.Add(firstMember);
        }

        internal void AddMember(ServerSidePlayer joinee)
        {
            if (Members.Contains(joinee) == false)
            {
                Members.Add(joinee);
            }
        }

        internal void Leave(ServerSidePlayer player)
        {
            Members.Remove(player);
        }
    }
}