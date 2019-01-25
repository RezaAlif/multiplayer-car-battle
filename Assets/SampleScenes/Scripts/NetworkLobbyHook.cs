using UnityEngine;
using Prototype.NetworkLobby;
using System.Collections;
using UnityEngine.Networking;

namespace UnityStandardAssets.Vehicles.Car
{
    public class NetworkLobbyHook : LobbyHook
    {
        public override void OnLobbyServerSceneLoadedForPlayer(NetworkManager manager, GameObject lobbyPlayer, GameObject gamePlayer)
        {
            LobbyPlayer lobby = lobbyPlayer.GetComponent<LobbyPlayer>();
            CarNetwork localPlayer = gamePlayer.GetComponent<CarNetwork>();

            localPlayer.pname = lobby.playerName;
        }
    }
}
