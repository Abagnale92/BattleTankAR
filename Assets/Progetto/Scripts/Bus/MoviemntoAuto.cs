using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoviemntoAuto : MonoBehaviour {
    bool curva1,curva2=false;


	void Update () {
        transform.Translate(0, 0, 0.8f); //Movimento 
        int posX=(int) transform.localPosition.x;
        int posZ = (int)transform.localPosition.z;
        int rotY = (int)transform.localEulerAngles.y;


        if (posX < -34 && rotY != 0 && !curva1)
        {
            curva2 = false;
            transform.Rotate(0, 1f, 0);
        }
        else if (posZ > 35 && rotY != 90&&!curva2)
        {
            transform.Rotate(0, 1f, 0);
            curva1 = true;
        }
        else if (posX > 35 && rotY != 180 && curva1)
        {
            curva2 = true;
            transform.Rotate(0, 1f, 0);
        }
        else if (posZ < -30 && rotY != 270&&curva2)
        {
            transform.Rotate(0, 1f, 0);
            curva1 = false;
        }


    }
}
