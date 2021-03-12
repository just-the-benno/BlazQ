using BlazQ.MultiplayerServer.Domain;
using BlazQ.Shared;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazQ.MultiplayerServer.Hubs
{
    public class LobbyHub : Hub<ILobbyClient>
    {
        public LobbyHub()
        {

        }

        public async Task JoinLobby(Guid id)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, id.ToString());
        }

        public async Task LeaveLobby(Guid id)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, id.ToString());
        }

        public async Task KeyPressed(String key, Guid sessionId)
        {
            await Clients.Group(sessionId.ToString()).KeyPressedReceived(new KeyPressedResponse{  Key = key });
        }
    }
}
