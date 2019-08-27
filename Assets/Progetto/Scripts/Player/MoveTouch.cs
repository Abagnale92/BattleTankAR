using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTouch: MonoBehaviour {

    private bool keyPressedright, keyPressedleft;
    private bool enabled = true;
    public Rigidbody rb;


    public void Start()
    {
        keyPressedright = false;
        keyPressedleft = false;
    }

    private void Update()
    {
        if (keyPressedright)
        {
            moveright();
        }
        else if(keyPressedleft) {
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

    public void moveright(){
        if (enabled)
        {
            rb.transform.Translate(0.8f, 0, 0);
        }
    }

    public void moveLeft(){

        if (enabled)
        {
            rb.transform.Translate(-0.8f, 0, 0); 
        }

    }

    public void setMove1(bool activate)
    {
        enabled = activate;
    }




}
