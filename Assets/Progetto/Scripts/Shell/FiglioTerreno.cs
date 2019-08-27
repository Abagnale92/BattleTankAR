using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FiglioTerreno : Photon.MonoBehaviour {

	// Use this for initialization
	void Start () {
        photonView.RPC("GitParent",PhotonTargets.All);

	}
    void Update()
    {
        
        transform.Translate(0, 0, 2f);
    }

    [PunRPC]
    void GitParent()
    {
        this.gameObject.transform.parent = GameObject.Find("Terrain").transform;
    }

}
