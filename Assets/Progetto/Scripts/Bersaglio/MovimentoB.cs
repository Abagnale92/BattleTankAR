
using UnityEngine;

public class MovimentoB : Photon.MonoBehaviour
{
    private float pos;

    void Start()
    {
        GameManager gm = FindObjectOfType<GameManager>();
        if (!gm.gameHasEnded)                                //necessario per assicurarsi che la rpc sia chiamata solo a gioco in corso
            photonView.RPC("GitParent", PhotonTargets.All);

        if (PhotonNetwork.isMasterClient)
        {
            pos = transform.localPosition.x;

            if (pos != 47) // controllo se Groucho parte da destra, se è così lo ruoto
            {
                transform.localEulerAngles = new Vector3(0f, 90f, 0f);  //ruota il modello di Groucho
            }
            else
            {
                transform.localEulerAngles = new Vector3(0f, 270f, 0f);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (PhotonNetwork.isMasterClient)
            transform.Translate(0, 0, 0.7f); //Movimento del Groucho
    }


    //se due Groucho collidono, entrambi tornano indietro

    private void OnCollisionEnter(Collision collision)
    {
        if (PhotonNetwork.isMasterClient)
        {
            if (collision.gameObject.name == "Groucho(Clone)")
            {
                if (pos != -47)
                {
                    pos = -47;  //è necessario cambiare pos altrimenti dopo una prima collisione, una eventuale seconda collisione non avrà effetto
                    transform.localEulerAngles = new Vector3(0f, 90f, 0f);  //ruota il modello di Groucho
                }
                else
                {
                    pos = 47;
                    transform.localEulerAngles = new Vector3(0f, 270f, 0f);  //ruota il modello di Groucho
                }
            }
        }
    }

    [PunRPC]
    void GitParent()
    {
        this.gameObject.transform.parent = GameObject.Find("Terrain").transform;
    }

}

