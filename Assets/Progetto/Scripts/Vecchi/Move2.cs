using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move2 : Photon.MonoBehaviour {
    public Rigidbody rb1;

   
    // Use this for initialization
    void Start () {
        photonView.TransferOwnership(2);
	}
	
	// Update is called once per frame
	void Update () {

            if (Input.GetKey(KeyCode.LeftArrow))
            {
            //rb1.AddForce(-40, 0, 0);
            rb1.transform.Translate(0.4f, 0, 0);
        }
            if (Input.GetKey(KeyCode.RightArrow))
            {
            //rb1.AddForce(40, 0, 0);
            rb1.transform.Translate(-0.4f, 0, 0);
        }
    }

}
