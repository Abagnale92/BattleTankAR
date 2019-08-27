
using UnityEngine;
using UnityEngine.UI;

public class FuocoTouchP1Fantasy : Photon.MonoBehaviour {
    
    private float nextFire;
    private float delay = 1f;
    private bool keyPressed;
    private GameObject shellInstance2;
    static public bool shoot,start,powerUp1;
    public Transform terrain;
    float timer;
    int second;
    public GameObject imagePowerUp;

    public void Start()
    {
        nextFire = 0;
        keyPressed = false;
        shoot=false;
        powerUp1 = false;
        start = false;
        timer = 15f;
        second = (int)(timer % 60);
    }

    private void Update()
    {
        if (start == true)    //questo if gestisce il tempo di attivazione del power up
        {
            imagePowerUp.SetActive(true);
            timer -= Time.deltaTime;
            second = (int)(timer % 60);
            delay = 0.5f;
            if (second == 0)                   //alla scadenza del tempo toglie il power up
            {
                imagePowerUp.SetActive(false);
                powerUp1 = false;            
                start = false;
                timer = 15f;
                second = (int)(timer % 60);
                delay = 1f;
            }
        }

        if (keyPressed)
        {
            firetouch();
        }

        if (shoot)
        {
            photonView.RPC("genera", PhotonTargets.MasterClient);
            shoot = false;
        }
    }

    public void onPress() {
        keyPressed = true;
        firetouch();

    }

    public void onRelase() {
        keyPressed = false;
    }

    public void firetouch()
    {
        if (Time.time > nextFire)
        {
            shoot = true;
            nextFire = Time.time + delay;
        }
    }

    [PunRPC]
    private void genera() {
        var cloneShell = transform.Find("FireTransform");
        shellInstance2 = (GameObject)PhotonNetwork.Instantiate("Shell", new Vector3(transform.localPosition.x, 4f, -43.122f), transform.rotation,0); //instanzia in rete 
        shellInstance2.transform.parent = terrain.transform;
        shellInstance2.transform.localPosition = new Vector3(transform.localPosition.x, 4f, -43.122f);
    }


    public void SetPowerUp(bool powerActive)
    {
        powerUp1 = powerActive;
        start = true;  //per far partire il timer sul powerUp
    }

}
