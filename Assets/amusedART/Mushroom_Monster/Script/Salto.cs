using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Salto : MonoBehaviour {

    bool goDown=false; 
	// Update is called once per frame
	void Update () {
        int posY = (int) transform.localPosition.y;

        if (posY > 3 && posY < 10 && !goDown)
        {
            transform.Translate(0, 0.3f, 0);
        }
        else if (posY == 10)
        {
            goDown = true;
        }
        if (goDown)
        {
            transform.Translate(0, -0.3f, 0);
            if (posY == 4)
                goDown = false;
        }


    }
}
