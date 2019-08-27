using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffettiSecondaSchermata : MonoBehaviour {

    public AudioSource audioSource;

    void Start()
    {
        if (PlayerPrefs.HasKey("effetti"))
            audioSource.volume = PlayerPrefs.GetFloat("effetti");
    }

}
