using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlane : MonoBehaviour {


	void Update () {

        transform.Translate(0, -0.8f, 0); //Movimento 
        int pos = (int)transform.localPosition.x;

        if(pos<-40||pos>40)
           transform.Rotate(0, 0, 0.7f);
    }
}
