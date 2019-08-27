using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTouch2 : Photon.MonoBehaviour {

    private bool keyPressedright, keyPressedleft;

    public Rigidbody rb1;

    public void Start()
    {
        photonView.TransferOwnership(2);
        keyPressedright = false;
        keyPressedleft = false;
    }

    private void Update()
    {
        if (keyPressedright)
        {
            moveright();
        }
        else if (keyPressedleft)
        {
            moveLeft();
        }
    }

    public void onPressR()
    {
        keyPressedright = true;
        moveright();
    }

    public void onRelaseR()
    {
        keyPressedright = false;
    }

    public void onPressL()
    {
        keyPressedleft = true;
        moveright();
    }

    public void onRelaseL()
    {
        keyPressedleft = false;
    }

    public void moveright()
    {
        if(enabled)
        rb1.transform.Translate(0.8f, 0, 0);
    }

    public void moveLeft()
    {
        if(enabled)
        rb1.transform.Translate(-0.8f, 0, 0);
    }

    public void setMove2(bool activate)
    {
        enabled = activate;
    }


}