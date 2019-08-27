using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class freezedMove2 : Photon.MonoBehaviour
{

    private MoveTouch2 pm;
    float timer;
    int second;
    bool start = false;
    public ParticleSystem scossa;

    private void Start()
    {
        
        timer = 7f;
        second = (int)(timer % 60);
    }

    private void Update()
    {
        if (start == true)
        {
            scossa.Play(true);
            timer -= Time.deltaTime;
            second = (int)(timer % 60);
            if (second == 0)
            {
                scossa.Stop(true);
                pm.setMove2(true);
                start = false;
                timer = 7f;
                second = (int)(timer % 60);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Shell(Clone)")
        {
            if (PhotonNetwork.isMasterClient)
                photonView.RPC("AttivaFreeze", PhotonTargets.All);
            pm = FindObjectOfType<MoveTouch2>();
            start = true;
            pm.setMove2(false);
            scossa.Play(true);
            if (PhotonNetwork.isMasterClient)
                PhotonNetwork.Destroy(collision.gameObject);
        }
    }

    [PunRPC]
    public void AttivaFreeze()
    {
        pm = FindObjectOfType<MoveTouch2>();
        start = true;
        pm.setMove2(false);
    }

}