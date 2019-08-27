using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForzaPortrait : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Screen.autorotateToPortrait = true;           //permette il l'orientamento a portrait
        Screen.autorotateToLandscapeLeft=false;   //impedisce l'orientamento landscape a sinistra
        Screen.autorotateToLandscapeRight = false;       //impedisce l'orientamento landscape a destra
        Screen.orientation =ScreenOrientation.Portrait;   //setta l'orientamento dellos chermo a portrait
    }


}
