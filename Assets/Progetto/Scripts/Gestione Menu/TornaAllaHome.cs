using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TornaAllaHome : MonoBehaviour
{
   
    public Text testoASchermo;

    private void Start()
    {
        if (SceneManager.GetActiveScene().name == "Schermata fine partita")
        {
            int punteggioP1 = PlayerPrefs.GetInt("PunteggioPlayer1"), punteggioP2 = PlayerPrefs.GetInt("PunteggioPlayer2");
            if (punteggioP1 > punteggioP2)
                testoASchermo.text = "Vince: " + PlayerPrefs.GetString("NickP1");
            else if (punteggioP2 > punteggioP1)
                testoASchermo.text = "Vince: "+ PlayerPrefs.GetString("NickP2");
            else
                testoASchermo.text = "Pareggio";
        }
    }


    public void OnClick_TornaAllaHome()
    {
        if (PhotonNetwork.connected)
        {
            if (PhotonNetwork.isMasterClient)
            {
                PhotonNetwork.DestroyAll();
            }
            Destroy(GameObject.Find("DDOLObject"));
            PhotonNetwork.LeaveRoom();
            PhotonNetwork.LeaveLobby();
            PhotonNetwork.Disconnect();
            SceneManager.LoadScene(0);
        }
        else
            SceneManager.LoadScene(0);
    }



    public void OnClick_TornaAllaHomeAFinePartita()
    {
        SceneManager.LoadScene(0);
    }

}