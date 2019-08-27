
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : Photon.MonoBehaviour {


    public bool gameHasEnded = false;
    float time = 5f;
    int punteggio = 0;
    public Text scorePlayerOne;
    public Text scorePlayerTwo;
    private bool check;


    public void Start()
    {
        PhotonNetwork.player.Get(1).SetScore(0);
        PhotonNetwork.player.Get(2).SetScore(0);
        PlayerPrefs.SetString("NickP1", PhotonNetwork.player.Get(1).NickName);
    }

    public void Update()
    {
        if (!gameHasEnded)
        {    
            if(PhotonNetwork.playerList.Length==2)
            {
                scorePlayerOne.text = PhotonNetwork.player.Get(1).NickName + " : " + PhotonNetwork.player.Get(1).GetScore();
                scorePlayerTwo.text = PhotonNetwork.player.Get(2).NickName + " : " + PhotonNetwork.player.Get(2).GetScore();
                PlayerPrefs.SetInt("PunteggioPlayer1", PhotonNetwork.player.Get(1).GetScore());
                PlayerPrefs.SetInt("PunteggioPlayer2", PhotonNetwork.player.Get(2).GetScore());
                PlayerPrefs.SetString("NickP2", PhotonNetwork.player.Get(2).NickName);
            }   
        }
    }

    public void endGame()
    {
        gameHasEnded = true;
       if (PhotonNetwork.isMasterClient)
       {
            PhotonNetwork.DestroyAll();
       }
        Destroy(GameObject.Find("DDOLObject"));
        PhotonNetwork.LeaveRoom();
        PhotonNetwork.LeaveLobby();
        PhotonNetwork.Disconnect();
        SceneManager.LoadScene(3);
    }

    public void addScorePlayer(int i)
    {
        if(i == 1)
        { 
            punteggio = PhotonNetwork.player.Get(1).GetScore() + 1;
            PhotonNetwork.player.Get(1).SetScore(punteggio);
            scorePlayerOne.text = PhotonNetwork.player.Get(1).NickName + " : " + PhotonNetwork.player.Get(1).GetScore();  
        }
        else if(i == 2)
        {
            punteggio = PhotonNetwork.player.Get(2).GetScore() + 1;
            PhotonNetwork.player.Get(2).SetScore(punteggio);
            scorePlayerTwo.text = PhotonNetwork.player.Get(2).NickName+" : " + PhotonNetwork.player.Get(2).GetScore();
        }
    }

    public int getScorePlayer(int i)
    {
        return i == 1 ? PhotonNetwork.player.Get(1).GetScore() : PhotonNetwork.player.Get(2).GetScore();
    }



}
