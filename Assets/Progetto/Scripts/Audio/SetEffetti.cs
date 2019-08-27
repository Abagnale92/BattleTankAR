using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetEffetti : MonoBehaviour {

    public Slider slider;

    public void Start()
    {
        if (PlayerPrefs.HasKey("effetti"))
            slider.value = PlayerPrefs.GetFloat("effetti");
        else
            slider.value = 0.75f;
    }

    public void OnClick()
    {
        PlayerPrefs.SetFloat("effetti", slider.value);
    }
}
