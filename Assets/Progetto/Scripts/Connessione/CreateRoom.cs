using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CreateRoom : MonoBehaviour {

    public Text avviso;

    void Update()
    {
        if (PhotonNetwork.playerList.Length == 2)
                PhotonNetwork.LoadLevel(2);
    }

    public void OnClick_CreateRoom()
    {
        RoomOptions roomOptions = new RoomOptions() { IsVisible = true, IsOpen = true, MaxPlayers = 2 };

        if (PhotonNetwork.JoinOrCreateRoom("Stanza", roomOptions,TypedLobby.Default))
        {
            avviso.text = "Stanza inviata";
        }
        else
        {
            avviso.text = "Creazione della stanza non inviata";
        }

    }



    private void OnPhotonCreateRoomFailed(object[] codeAndMessage)
    {
        print("Creazione della stanza fallita, con codice di errore "+codeAndMessage[1]);
    }


    private void OnCreatedRoom()
    {
        avviso.text = "Stanza creata";  
    }

    private void OnJoinedRoom()
    {
        if (PhotonNetwork.isMasterClient)
        {
            PhotonNetwork.player.Get(1).NickName = PlayerPrefs.GetString("nickname");  //setta il nome del primo player in rete
        }
        else
        {
            PhotonNetwork.player.Get(2).NickName = PlayerPrefs.GetString("nickname"); //setta il nome del secondo player in rete
        }
    }



    private void OnLeftRoom()
    {
        if (PhotonNetwork.isMasterClient)
        {
            Debug.Log("Lascio la stanza");
            PhotonNetwork.player.Get(1).SetScore(0);
            PhotonNetwork.player.Get(2).SetScore(0);
        }
    }

    //se l'host abbandona tutti escono dal gioco
    private void OnMasterClientSwitched(PhotonPlayer newMasterClient)
    {
        PhotonNetwork.LeaveRoom();
    }

}
