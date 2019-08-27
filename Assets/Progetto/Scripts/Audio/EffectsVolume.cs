using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EffectsVolume : MonoBehaviour
{
    public Slider slider;
    public AudioSource audioSource;

    void Start()
    {
        if (PlayerPrefs.HasKey("effetti"))
            slider.value = PlayerPrefs.GetFloat("effetti");
    }

    void Update()
    {
        audioSource.volume = PlayerPrefs.GetFloat("effetti");
    }

}
