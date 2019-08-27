using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestioneVolume : MonoBehaviour {

	
	// Update is called once per frame
	void Update () {
        this.GetComponent<AudioSource>().volume= PlayerPrefs.GetFloat("effetti");
    }
}
