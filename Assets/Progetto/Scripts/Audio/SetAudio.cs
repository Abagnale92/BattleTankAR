using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetAudio : MonoBehaviour {

    public Slider slider;

    public void Start()
    {
        if (PlayerPrefs.HasKey("music"))
            slider.value = PlayerPrefs.GetFloat("music");
        else
            slider.value = 0.75f;
    }

    public void OnClick()
    {
        PlayerPrefs.SetFloat("music", slider.value);
    }
}
