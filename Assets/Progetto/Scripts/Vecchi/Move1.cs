using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move1 : MonoBehaviour {
    public Rigidbody rb;

 
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

        if(Input.GetKey("a")){
            //rb.AddForce(40, 0, 0);
            rb.transform.Translate(0.4f, 0, 0);
        }
        if(Input.GetKey("d")){
            //rb.AddForce(-40, 0, 0);
            rb.transform.Translate(-0.4f, 0, 0);
        }

       

    }
}
