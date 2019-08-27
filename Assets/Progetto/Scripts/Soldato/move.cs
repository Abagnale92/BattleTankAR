using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour {

	
	// Update is called once per frame
	void Update () {
        if(this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Corri"))  //se parte l'animazione corsa
             transform.Translate(0, 0, 0.5f); //Movimento 

        int pos =(int) transform.localPosition.x;

        if (pos == 30)
            transform.localEulerAngles=new Vector3(0,270,0);
        if(pos==-60)
            transform.localEulerAngles = new Vector3(0, 90, 0);
    }

}
