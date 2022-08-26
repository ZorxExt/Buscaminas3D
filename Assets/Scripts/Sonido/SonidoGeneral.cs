using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SonidoGeneral : MonoBehaviour
{
    private static SonidoGeneral instance = null;
    public AudioMixer audioMix;
    public float sonidoGeneral;
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

    private void Update()
    {
        audioMix.GetFloat("MusicVol",out sonidoGeneral);
    }
}
