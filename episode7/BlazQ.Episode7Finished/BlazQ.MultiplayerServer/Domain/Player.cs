using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazQ.MultiplayerServer.Domain
{
    public class PlayerServerSide
    {
        public String Name { get; init; }
        public String AvatarUrl { get; init; }
        public Guid Id { get; init; }
        public Lobby Lobby { get; private set; }

        public PlayerServerSide(String name, String avatarUrl, Guid id)
        {
            Name = name;
            AvatarUrl = avatarUrl;
            Id = id;
            Lobby = new Lobby(this);
        }

        public void LeaveLobby()
        {
            Lobby.Leave(this);
            Lobby = new Lobby(this);
        }

        public void JoinLobby(PlayerServerSide player)
        {
            player.Lobby.Join(this);
            this.Lobby = player.Lobby;
        }

        //public void SendInvite(Player other)
        //{
        //    other._openInvitations.Add(this);
        //}

        //public void AcceptInvite(Player inviter)
        //{
        //    if(_openInvitations.Contains(inviter) == false)
        //    {
        //        return;
        //    }

        //    _openInvitations.Remove(inviter);   
        //    LeaveLobby();
            
        //}

        //public void RejectInivte()
        //{

        //}

    }
}
