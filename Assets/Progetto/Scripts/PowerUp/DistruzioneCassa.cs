using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistruzioneCassa : MonoBehaviour {
    

	void Update () {
        int posY =(int) transform.localPosition.y;

        if (posY == 12 && PhotonNetwork.isMasterClient)
            PhotonNetwork.Destroy(this.gameObject);       
	}
}
