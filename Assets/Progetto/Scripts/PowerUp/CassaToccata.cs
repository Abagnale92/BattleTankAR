using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CassaToccata : Photon.MonoBehaviour {


    void OnTouchDown()
    {
        if (!PhotonNetwork.isMasterClient)
        {
            photonView.TransferOwnership(2);                        //trasferisce la proprietà della cassa al secondo player
            FuocoTouch2 fuocoTouch2= FindObjectOfType<FuocoTouch2>();
            fuocoTouch2.SetPowerUp(true);                                      //richiama il metodo setpowerup in FuocoTouch2 per abilitare il power up
        }

        else
        {
            FuocoTouch fuocoTouch= FindObjectOfType<FuocoTouch>();
            fuocoTouch.SetPowerUp(true);                                       //richiama il metodo setpowerup in FuocoTouch2 per abilitare il power up
        }

        PhotonNetwork.Destroy(this.gameObject);  //distruzione della cassa online
    }
}
