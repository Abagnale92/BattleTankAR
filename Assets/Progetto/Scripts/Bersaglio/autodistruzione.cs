using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class autodistruzione : MonoBehaviour {

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Border3" || collision.gameObject.name == "Border4" || collision.gameObject.name == "Border1" || 
        collision.gameObject.name == "Border2" || collision.gameObject.name == "Player1" || collision.gameObject.name == "Player2")
        {

            if (PhotonNetwork.isMasterClient)
                PhotonNetwork.Destroy(this.gameObject);
        }
    }
}
