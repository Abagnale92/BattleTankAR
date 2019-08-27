using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FiglioDelTerrenoCassa : MonoBehaviour {


	
	void Start () {
        if (!PhotonNetwork.isMasterClient)
            transform.parent = GameObject.Find("Terrain").transform;
    }
}
