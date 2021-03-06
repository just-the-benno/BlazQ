﻿using BlazQ.MultiplayerServer.Domain;
using BlazQ.MultiplayerServer.Hubs;
using BlazQ.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazQ.MultiplayerServer.Controller
{
    [ApiController]
    public class LobbyController : ControllerBase
    {
        private readonly PlayerRegistry playerRegistry;
        private readonly IHubContext<LobbyHub, ILobbyClient> lobbyHubContext;

        public LobbyController(PlayerRegistry playerRegistry, IHubContext<LobbyHub, ILobbyClient> _lobbyHubContext)
        {
            this.playerRegistry = playerRegistry ?? throw new ArgumentNullException(nameof(playerRegistry));
            lobbyHubContext = _lobbyHubContext ?? throw new ArgumentNullException(nameof(_lobbyHubContext));
        }

        [HttpPost("/api/Lobby/Player")]
        public async Task<IActionResult> AddPlayer([FromBody] CreatePlayerRequest request)
        {
            PlayerServerSide player = new PlayerServerSide(request.Name, request.AvatarUrl, request.Id);
            playerRegistry.AddPlayer(request.Id, player);

            await lobbyHubContext.Clients.All.NewPlayer(new ServerSidePlayerOverview
            {
                AvatarUrl = request.AvatarUrl,
                Id = request.Id,
                Name = request.Name,
            });

            Guid lobbyId = playerRegistry.GetLobbyIdByPlayerId(request.Id);
            return base.Ok(new AddPlayerResponse { LobbyId = lobbyId });
        }

        [HttpGet("/api/Lobby/Players")]
        public IActionResult GetAllPlayers()
        {
            List<ServerSidePlayerOverview> result = playerRegistry.GetAllPlayers();
            return base.Ok(result);
        }

        private async Task NotifyLobbyAboutLeave(Guid playerId)
        {
            Guid lobbyId = playerRegistry.GetLobbyIdByPlayerId(playerId);
            if(playerRegistry.GetPlayerAmountForLobby(playerId) > 1)
            {
                await lobbyHubContext.Clients.Group(lobbyId.ToString()).PlayerLeavedLobby(playerId);
            }
        }

        [HttpPost("/api/Lobby/Join")]
        public async Task<IActionResult> JoinLobby([FromBody] ServerSideJoinLobbyRequest request)
        {
            await NotifyLobbyAboutLeave(request.PlayerId);
            Boolean joined = playerRegistry.JoinLobby(request.HostId, request.PlayerId);
            return await GetJoinLobbyResponse(joined, request.PlayerId, true);
        }

        private async Task<IActionResult> GetJoinLobbyResponse(Boolean result, Guid playerId, Boolean sendMessageIntoLobby)
        {
            if (result == false)
            {
                return BadRequest();
            }


            PlayerServerSide player = playerRegistry.GetPlayerById(playerId);
            Guid lobbyId = playerRegistry.GetLobbyIdByPlayerId(playerId);
            if (sendMessageIntoLobby == true)
            {
                await lobbyHubContext.Clients.Group(lobbyId.ToString()).PlayerJoinedLobby(GetPlayerOverview(player));
            }

            List<ServerSidePlayerOverview> playerInLobby = new();
            foreach (var item in player.Lobby.Players)
            {
                playerInLobby.Add(GetPlayerOverview(item));
            }

            return base.Ok(new JoinLobbyResponse
            {
                LobbyId = lobbyId,
                PlayersInLobby = playerInLobby,
            });
        }

        [HttpPost("/api/Lobby/Leave")]
        public async Task<IActionResult> LeaveLobby([FromBody] ServerSideLeaveLobbyRequest request)
        {
            await NotifyLobbyAboutLeave(request.PlayerId);
            Boolean joined = playerRegistry.LeaveLobby(request.PlayerId);
            return await GetJoinLobbyResponse(joined, request.PlayerId, false);
        }

        private static ServerSidePlayerOverview GetPlayerOverview(PlayerServerSide player)
        {
            return new ServerSidePlayerOverview
            {
                AvatarUrl = player.AvatarUrl,
                Id = player.Id,
                Name = player.Name,
            };
        }
    }
}
