using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForzaLandScape : MonoBehaviour {


	void Start () {
        Screen.autorotateToPortrait = false;   //blocca il portrait
        Screen.autorotateToLandscapeRight = true;   //permette il landscape a destra
        Screen.autorotateToLandscapeLeft = true;            //permette il landscape a sinistra
        Screen.orientation = ScreenOrientation.Landscape;  //setta a landscape l'orientamento dello schermo
    }
}
