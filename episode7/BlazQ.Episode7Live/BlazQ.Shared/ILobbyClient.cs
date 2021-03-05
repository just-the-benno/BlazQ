using System.Threading.Tasks;
using BlazQ.Shared.Responses;

namespace BlazQ.Shared
{
    public interface ILobbyClient
    {
         Task NewPlayer(ServerSidePlayerOverview newPlayer);
         Task NewPlayerInLobby(ServerSidePlayerOverview newPlayer);
    }
}