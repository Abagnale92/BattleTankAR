
using UnityEngine;
using UnityEngine.UI;

public class Distruzione : MonoBehaviour {


    private void OnCollisionEnter(Collision collision)
    {
    
        if(collision.gameObject.name == "Player1" || collision.gameObject.name == "Border3" || collision.gameObject.name == "Border4"
          || collision.gameObject.name == "Border1" || collision.gameObject.name == "Border2"|| collision.gameObject.name == "Terrain"|| 
            collision.gameObject.name == "Shell2(Clone)")
        {
            if (PhotonNetwork.isMasterClient)
               PhotonNetwork.Destroy(this.gameObject);
        }
        else if(collision.gameObject.name == "Groucho(Clone)"){
            if (PhotonNetwork.isMasterClient)
            {
                PhotonNetwork.Destroy(this.gameObject);
                PhotonNetwork.Destroy(collision.gameObject);
                FindObjectOfType<GameManager>().addScorePlayer(1);
            }    
        }
    }
}
