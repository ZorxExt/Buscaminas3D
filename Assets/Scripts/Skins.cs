using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Skins : MonoBehaviour
{
    public GameObject luzAdentro;
    public GameObject luzAfuera;
    public GameObject corazon;
    
    
    public enum Skin
    {
        AquaInferno,
        BlancoNegro,
        NaranjaVerde
    }

    private int _index = 0;
    private readonly Skin[] _skinsNames = new Skin[Enum.GetValues(typeof(Skin)).Length];

    public Skin skinActual;


    void Start()
    {
        MakeArray();
    }
    

    void Update()
    {
        
        //Poner la skin (en caso de que haya una)
        SetSkin(skinActual);
        
        
        //Input
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            NextSkin();
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            PreviousSkin();
        }
    }
    
    public void MakeArray()
    {
        int i = 0;
        
        foreach(Skin item in Enum.GetValues(typeof(Skin)))
        {
            Debug.Log(item);
            _skinsNames[i] = item;
            i++;
        }
    }


    public void NextSkin()
    {
        _index++;
        try
        {
            skinActual = _skinsNames[_index];
        }
        catch
        {
            skinActual = _skinsNames[0];
            _index = 0;
        }

    }

    public void PreviousSkin()
    {
        _index--;
        try
        {
            skinActual = _skinsNames[_index];
        }
        catch
        {
            int lastIndex = _skinsNames.Length - 1;
            skinActual = _skinsNames[lastIndex];
            _index = lastIndex;
        }
    }
    
    public void SetSkin(Skin skin)
    {
        //Color por default
        Color colorCorazon = new Color (0.0f, 0.0f, 0.0f, 0.7f); //Negro transparentito
        Color colorLuzAdentro = Color.red;
        Color colorLuzAfuera = Color.red;

        switch (Renderizado.renderizado.temaOscuro)
        {
            
            case true: //Cubos blancos
                switch (skin)
                {
                    case Skin.AquaInferno:
                        colorCorazon = new Color(0.1368f,0.4284f,0.7075f,0.6823f);
                        colorLuzAdentro = new Color(0f,0.7176f,0.7176f,1f);
                        colorLuzAfuera = new Color(0.2470f, 0.2039f, 0.7921f);
                        break;
                    
                    case Skin.BlancoNegro:
                        colorCorazon = new Color (0.0f, 0.0f, 0.0f, 0.9f);
                        colorLuzAdentro = new Color(0.1f, 0.1f, 0.1f);
;                        colorLuzAfuera = Color.gray;
                        break;
                    
                    case Skin.NaranjaVerde:
                        colorCorazon = new Color(0.0f, 0.0f, 0.0f, 0.7f);
                        colorLuzAdentro = new Color(1f, 0.3f, 0.1f);
                        colorLuzAfuera = new Color(0.2f, 0.3f, 0.1f, 0.6f);
                        break;
                }
                break;
            
            
            case false: //Cubos negros
                switch (skin)
                {
                    case Skin.AquaInferno:
                        colorCorazon = new Color(0.3962f, 0f, 0f, 0.3764f);
                        colorLuzAdentro = new Color(0.9921f, 0f, 0.1568f);
                        colorLuzAfuera = new Color(0.2470f, 0.2039f, 0.7921f);
                        break;
                    
                    case Skin.BlancoNegro:
                        colorCorazon = new Color(0f,0f,0f,0.8f);
                        colorLuzAdentro = new Color(1.0f, 1.0f, 1.0f, 0.5f);
                        colorLuzAfuera = Color.white;
                        break;
                    
                    case Skin.NaranjaVerde:
                        colorCorazon = new Color(0.0f, 0.0f, 0.0f, 0.5f);
                        colorLuzAdentro = new Color(0.6f, 0.9f, 0.0f);
                        colorLuzAfuera = new Color(1f, 0.3f, 0.1f);
                        break;
                }
                break;
        }

        luzAfuera.GetComponent<Light>().color = colorLuzAfuera;
        luzAdentro.GetComponent<Light>().color = colorLuzAdentro;
        corazon.GetComponent<Renderer>().material.color = colorCorazon;
    }

}
