using UnityEngine;
using UnityEngine.UI;

public class PowerUp1 : Photon.MonoBehaviour
{

    private GameObject powerUp;
    public GameObject power;
    private int random = 0;
    public Transform terrain;
    GameManager gm;
    public bool find2;
    public bool find;

    // Use this for initialization
    void Start()
    {
        find = false;
        find2 = false;
        gm = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!PhotonNetwork.isMasterClient && (GameObject.Find("ImageTarget").GetComponent<DefaultTrackableEventHandler>().find || GameObject.Find("ImageTargetFantasy").GetComponent<DefaultTrackableEventHandler>().find || GameObject.Find("ImageTargetCity").GetComponent<DefaultTrackableEventHandler>().find))
        {
            photonView.RPC("TerrenoTrovato2", PhotonTargets.All);
        }
        if (PhotonNetwork.isMasterClient && (GameObject.Find("ImageTarget").GetComponent<DefaultTrackableEventHandler>().find || GameObject.Find("ImageTargetFantasy").GetComponent<DefaultTrackableEventHandler>().find || GameObject.Find("ImageTargetCity").GetComponent<DefaultTrackableEventHandler>().find))
        {
           photonView.RPC("TerrenoTrovato", PhotonTargets.All);
        }

        float n = Random.Range(-180, 180);
        if (!gm.gameHasEnded)
        {
           if (random == n)
            {
                if (PhotonNetwork.isMasterClient && find && find2)
                {
                    photonView.RPC("InstantiatePowerUp", PhotonTargets.MasterClient);
                }
           }
        }
    }

 

    [PunRPC]
    void InstantiatePowerUp()
    {
        powerUp = (GameObject)PhotonNetwork.Instantiate("Cargo", transform.position,new Quaternion(0,0,0,0), 0);
        powerUp.transform.parent = terrain.transform;
        powerUp.transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.z);
        powerUp.transform.localEulerAngles = new Vector3(0,0,0);
    }

    [PunRPC]
    void TerrenoTrovato2()
    {
        find2 = true;
    }
    [PunRPC]
    void TerrenoTrovato()
    {
        find = true;
    }



}

