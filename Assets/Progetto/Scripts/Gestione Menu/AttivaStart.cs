using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AttivaStart : MonoBehaviour {
    public Text avviso;
    public Button statButton;

	void Update () {
        if (avviso.text.Equals("Premi start per iniziare"))
        {
            statButton.gameObject.SetActive(true);
        }
	}
}
