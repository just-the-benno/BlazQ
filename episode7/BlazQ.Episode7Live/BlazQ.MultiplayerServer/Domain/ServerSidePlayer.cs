using System;

namespace BlazQ.MultiplayerServer.Domain
{
    public class ServerSidePlayer
    {
        public string Name {get; init;}
        public string AvatarUrl {get; init;}

        public Guid Id {get; init;}

        public Lobby Lobby {get; private set;}

        public ServerSidePlayer(String name, String avatar)
        {
            Name = name;
            AvatarUrl = avatar;
            Id = Guid.NewGuid();

            Lobby = new Lobby(this);
        }

        internal void Join(ServerSidePlayer joinee)
        {
            joinee.LeaveLobby();
            Lobby.AddMember(joinee);
            joinee.Lobby = Lobby;
        }

        private void LeaveLobby()
        {
            Lobby.Leave(this);
        }
    }
}