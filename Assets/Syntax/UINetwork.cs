using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class UINetwork : MonoBehaviour {
    public GameObject panelKoneksi;

    public Button btnHost;
    public Button btnJoin;
    public Button btnCancel;

    public Text txInfo;

    int status = 0;

    NetworkManager network;

    // Use this for initialization
    void Start()
    {
        panelKoneksi.transform.localPosition = Vector3.zero;
        btnHost.onClick.AddListener(StartHostGame);
        btnJoin.onClick.AddListener(StartJoinGame);
        btnCancel.onClick.AddListener(CancelConnection);
        btnCancel.interactable = false;
        network = GameObject.Find("Network Manager").GetComponent<NetworkManager>();
        network.playerSpawnMethod = PlayerSpawnMethod.RoundRobin;
        txInfo.text = "Info: Server Address " + network.networkAddress + " with port " + network.networkPort;
    }

    // Update is called once per frame
    void Update()
    {
        if (NetworkClient.active || NetworkServer.active)
        {
            btnHost.interactable = false;
            btnJoin.interactable = false;
            btnCancel.interactable = true;
        }
        else
        {
            btnHost.interactable = true;
            btnJoin.interactable = true;
            btnCancel.interactable = false;
        }
        if (NetworkServer.connections.Count == 2 && status == 0)
        {
            status = 1;
            MulaiPermainan();
        }
        if (ClientScene.ready && !NetworkServer.active && status == 0)
        {
            status = 1;
            MulaiPermainan();
        }
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            KembaliKeMenu();
        }
    }

    private void StartHostGame()
    {
        if (!NetworkServer.active)
        {
            network.StartHost();
        }
        if (NetworkServer.active) txInfo.text = "Info: Menunggu Player lain (Jika Server Aktif)";
    }

    private void StartJoinGame()
    {
        if (!NetworkClient.active)
        {
            network.StartClient();
            network.client.RegisterHandler(MsgType.Disconnect, ConnectionError);
        }
        if (NetworkClient.active) txInfo.text = "Info: Mencoba mengkoneksikan dengan Server";
    }

    private void ConnectionError(NetworkMessage netMsg)
    {
        network.StopClient();
        txInfo.text = "Info: Koneksi terputus dari Server";
        //network.StopClient();
        //txInfo.text = "Info: Koneksi terputus dari Server";
        KembaliKeMain();
    }

    private void CancelConnection()
    {
        network.StopHost();
        btnHost.interactable = true;
        btnJoin.interactable = true;
        btnCancel.interactable = false;
        txInfo.text = "Info: Server Address " + network.networkAddress + " with port " + network.networkPort;
    }

    public void MulaiPermainan()
    {
        panelKoneksi.transform.localPosition = new Vector3(-1500, 0, 0);
    }
    public void KembaliKeMain()
    {
        network.StopHost();
        SceneManager.LoadScene("Main");
    }
    public void KembaliKeMenu()
    {
        network.StopHost();
        SceneManager.LoadScene("Menu");
    }
}
