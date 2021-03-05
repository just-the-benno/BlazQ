using Microsoft.AspNetCore.Mvc;
using BlazQ.Shared.Requets;
using BlazQ.MultiplayerServer.Domain;
using BlazQ.Shared.Responses;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.SignalR;
using BlazQ.MultiplayerServer.Hubs;
using BlazQ.Shared;
using System.Threading.Tasks;
using System;

namespace BlazQ.MultiplayerServer.Controllers
{
    [ApiController]
    public class LobbyController : ControllerBase
    {
        private readonly PlayerRegistry _registry;
        private readonly IHubContext<LobbyHub, ILobbyClient> _hubContext;

        public LobbyController(
            PlayerRegistry registry,
            IHubContext<LobbyHub,ILobbyClient> hubContext
            )
        {
            this._registry = registry;
            this._hubContext = hubContext;
        }
        
        [HttpPost("api/Lobby/Player")]
        public async Task<IActionResult> AddPlayer([FromBody]AddPlayerRequest request)
        {
            ServerSidePlayer player = new ServerSidePlayer(request.Name,request.AvatarUrl);
            _registry.AddPlayer(player);

            AddPlayerResponse response = new AddPlayerResponse
            {
                PlayerId = player.Id,
                LobbyId = player.Lobby.Id,
            };

            await _hubContext.Clients.All.NewPlayer(new ServerSidePlayerOverview
            {
                Id = player.Id,
                Name = player.Name,
                AvatarUrl = player.AvatarUrl,
            });
          
            return base.Ok(response);
        }

        private List<ServerSidePlayerOverview> GetOverviewFromPlayer(
            IEnumerable<ServerSidePlayer> players)
        {
 List<ServerSidePlayerOverview> result = players.Select(x => new ServerSidePlayerOverview {
                Id = x.Id,
                Name = x.Name,
                AvatarUrl = x.AvatarUrl,
            }).ToList();

            return result;
        }

        [HttpGet("api/Lobby/Players")]
        public IActionResult GetAllPlayers()
        {
           IEnumerable<ServerSidePlayer> players = _registry.GetAllPlayers();

            return base.Ok(new GetAllPlayersResponse {
                Players = GetOverviewFromPlayer(players),
            });
        }

        [HttpPost("api/Lobby/Join")]
        public async Task<IActionResult> JoinLobby([FromBody]JoinLobbyRequest request)
        {
            Guid lobbyId = _registry.JoinLobby(request.HostId,request.JoineeId);

            ServerSidePlayer joinee = _registry.GetPlayerById(request.JoineeId);

            List<ServerSidePlayer> members = _registry.GetLobbyMembers(request.HostId);

                await _hubContext.Clients.Group(lobbyId.ToString()).NewPlayerInLobby(new ServerSidePlayerOverview{
                    Id = joinee.Id,
                    AvatarUrl = joinee.AvatarUrl,
                    Name = joinee.Name,
                });

            return base.Ok(new JoinLobbyResponse{
                LobbyId = lobbyId,
                Members = GetOverviewFromPlayer(members)
            });
        }

    }
}