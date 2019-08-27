using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerNetwork : MonoBehaviour {
    public static PlayerNetwork Instance;
    public string PlayerName { get; private set; }
    private PhotonView PhotonView;

    private void Awake()
    {
        Instance = this;
        PhotonView = GetComponent<PhotonView>();     
    }

   private void OnSceneFinishedLoading(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "Game")
        {
            if (PhotonNetwork.isMasterClient)
                MasterLoadedGame();
            else
                NonMasterLoadedGame();
        }
    }

    private void MasterLoadedGame()
    {
        PhotonView.RPC("RPC_LoadGameOthers",PhotonTargets.Others);
    }

    private void NonMasterLoadedGame()
    {
        PhotonView.RPC("RPC_LoadedGameScene", PhotonTargets.MasterClient);
    }


    [PunRPC]
    private void RPC_LoadGameOthers()
    {
        PhotonNetwork.LoadLevel(2); //carica la scena 2 cioè Game
    }

    [PunRPC]
    private void RPC_LoadedGameScene()
    {
        if (PhotonNetwork.playerList.Length == 2) //se ci sono tutti i player nella scena
        {
            PhotonView.RPC("RPC_CreatePlayer1",PhotonTargets.MasterClient);
            PhotonView.RPC("RPC_CreatePlayer2", PhotonTargets.Others);
        }
    }


    [PunRPC]
    private void RPC_CreatePlayer2()
    {
        PhotonNetwork.Instantiate("Player2",new Vector3(1,0,37),Quaternion.identity,0);  
    }

    [PunRPC]
    private void RPC_CreatePlayer1()
    {
        PhotonNetwork.Instantiate("Player1",new Vector3(1,0,-87), Quaternion.identity, 0);
    }

}
