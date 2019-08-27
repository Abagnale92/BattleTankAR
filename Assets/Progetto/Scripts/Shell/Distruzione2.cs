using UnityEngine;
using UnityEngine.UI;

public class Distruzione2 : Photon.MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player2" || collision.gameObject.name == "Border3" || collision.gameObject.name == "Border4"
          || collision.gameObject.name == "Border1" || collision.gameObject.name == "Border2" || collision.gameObject.name == "Terrain" || 
            collision.gameObject.name == "Shell(Clone)")
        {
            if (!PhotonNetwork.isMasterClient)
                PhotonNetwork.Destroy(this.gameObject);
        }
        else if (collision.gameObject.name == "Groucho(Clone)")
        {
            if (!PhotonNetwork.isMasterClient)
            {
                collision.gameObject.GetComponent<PhotonView>().TransferOwnership(2);
                PhotonNetwork.Destroy(collision.gameObject);
                PhotonNetwork.Destroy(this.gameObject);
                FindObjectOfType<GameManager>().addScorePlayer(2);
            }
        }
    }
}