using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour {

    public GameObject pannello1;
    public GameObject pannello2;

    // Use this for initialization
    void Start () {
        if (PhotonNetwork.isMasterClient)
        {
            pannello1.SetActive(true); pannello2.SetActive(false);
          
        }

        else
        {
            pannello1.SetActive(false); pannello2.SetActive(true);
        }
    }


}
