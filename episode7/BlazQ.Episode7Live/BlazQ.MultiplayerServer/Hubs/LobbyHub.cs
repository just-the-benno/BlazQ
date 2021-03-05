using System;
using System.Threading.Tasks;
using BlazQ.Shared;
using Microsoft.AspNetCore.SignalR;

namespace BlazQ.MultiplayerServer.Hubs
{
    public class LobbyHub : Hub<ILobbyClient>
    {
        public async Task JoinLobby(Guid lobbyId)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId,lobbyId.ToString());
        }
    }
}