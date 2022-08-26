using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UIElements;
using Slider = UnityEngine.UI.Slider;

public class BarraDeSonido : MonoBehaviour
{
    public AudioMixer AudioMix;
    private float _volumenInicial;

    private void Start()
    {
        AudioMix.GetFloat("MusicVol",out _volumenInicial);

        gameObject.GetComponent<Slider>().value = Mathf.Pow(10,_volumenInicial/20);
    }
    

    public void VolumenSlider(float sliderValue)
    {
        AudioMix.SetFloat("MusicVol", MathF.Log10(sliderValue) * 20);
    }
    
}