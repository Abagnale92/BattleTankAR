using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MusicVolume : MonoBehaviour
{
    public Slider slider;
    public AudioSource audioSource;

    void Start()
    {
        if (PlayerPrefs.HasKey("music"))
            slider.value = PlayerPrefs.GetFloat("music");
    }

     void Update()
    {
        audioSource.volume = PlayerPrefs.GetFloat("music");
    }
}
