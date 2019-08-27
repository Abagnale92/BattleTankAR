using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LobbyNetwork : MonoBehaviour {

    public Text avviso;

    void Start ()
    {
        if (!PhotonNetwork.connected)
        {
            avviso.text = "Connessione in corso, attendere...";
            PhotonNetwork.ConnectUsingSettings("0.9v");
        }
    }

    private void OnConnectedToMaster()
    {
        PhotonNetwork.playerName = PlayerNetwork.Instance.PlayerName;
        PhotonNetwork.JoinLobby(TypedLobby.Default);
    }

    private void OnJoinedLobby()
    {
        avviso.text = "Premi start per iniziare";
    }
}
