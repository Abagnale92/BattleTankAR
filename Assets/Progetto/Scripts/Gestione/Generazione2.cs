using UnityEngine;
using UnityEngine.UI;

public class Generazione2 : Photon.MonoBehaviour {

    public GameObject enemies;
    private GameObject enemy;
    public Vector3 spawnValues;
    private int random = 0;
    public Transform terrain;
    GameManager gm;
    Vector3 spawnPosition;
    public bool find2;
    public bool find;

    // Use this for initialization
    void Start () {
        find = false;
        find2 = false;
        gm = FindObjectOfType<GameManager>();                 
    }

    // Update is called once per frame
    void Update()
    {

        if (!PhotonNetwork.isMasterClient && GameObject.Find("ImageTargetFantasy").GetComponent<DefaultTrackableEventHandler>().find) {
            photonView.RPC("TerrenoTrovatoF2", PhotonTargets.All);
        }
        if(PhotonNetwork.isMasterClient &&  GameObject.Find("ImageTargetFantasy").GetComponent<DefaultTrackableEventHandler>().find){
            photonView.RPC("TerrenoTrovatoF", PhotonTargets.All);
        }

        float n = Random.Range(-50, 50);
       
        if (!gm.gameHasEnded)
        {
            if (random == n)
            {
                if (PhotonNetwork.isMasterClient && find  && find2)
                {
                    photonView.RPC("InstantiateBersaglioF", PhotonTargets.MasterClient);
                }
            }
    
        }
    }

    //usato per generare la posizione sull'asse delle x
    public static int RandomPosX()
    {
        return Random.value <0.5  ? -47 : 47;
    }

   
    [PunRPC]
   void InstantiateBersaglioF()
    {
        spawnPosition = new Vector3(RandomPosX(), 0, Random.Range(-spawnValues.z, spawnValues.z));
        enemy = (GameObject)PhotonNetwork.Instantiate(enemies.name, spawnPosition, new Quaternion(spawnPosition.x, spawnPosition.y, spawnPosition.z,0),0);
        enemy.transform.parent = terrain.transform;
        enemy.transform.localPosition = spawnPosition;
    }

    [PunRPC]
    void TerrenoTrovatoF2() {
        find2 = true;
    }
    [PunRPC]
    void TerrenoTrovatoF()
    {
        find = true;
    }



}








