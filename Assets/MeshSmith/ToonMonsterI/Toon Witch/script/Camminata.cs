using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camminata : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(0,0,0.5f);
        int posZ =(int) transform.localPosition.z;

        if (posZ == 70)
            transform.localEulerAngles = new Vector3(0,0f,0);
        else if(posZ==86)
            transform.localEulerAngles = new Vector3(0, 180f, 0);
    }
}
