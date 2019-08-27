using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvaterRotate : MonoBehaviour {

    

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.LeftArrow)){
            transform.transform.Rotate(new Vector3(0, 5, 0));
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.transform.Rotate(new Vector3(0, -5, 0));
        }
    }
}
