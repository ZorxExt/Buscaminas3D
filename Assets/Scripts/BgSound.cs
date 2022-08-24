using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;

public class BgSound : MonoBehaviour
{
    private static BgSound instance = null;
    public AudioMixer audioControl;
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
    }
    
    public void VolumenSlider(float sliderValue)
    {
        audioControl.SetFloat("MusicVol", MathF.Log10(sliderValue) * 20);
    }
    
    
}
