using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

namespace UnityStandardAssets.Vehicles.Car
{
    // Subclass this and redefine the function you want
    // then add it to the lobby prefab
    public abstract class LobbyHook : MonoBehaviour
    {
        public virtual void OnLobbyServerSceneLoadedForPlayer(NetworkManager manager, GameObject lobbyPlayer, GameObject gamePlayer)
        {
            
        }
    }

}
