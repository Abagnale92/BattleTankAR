using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioVolume : MonoBehaviour
{
    public Slider audioVolume;
    public AudioSource audioSource;

    // Update is called once per frame
    void Update()
    {
        audioSource.volume = audioVolume.value;
    }
}
