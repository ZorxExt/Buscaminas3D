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
        Azul,
        Rojo,
        Green
    }

    public int index = 0;
    public Skin[] skinsNames = new Skin[Enum.GetValues(typeof(Skin)).Length];
    public bool newSkin = true;
    
    public Skin skinActual;

    // Start is called before the first frame update
    void Start()
    {
        MakeArray();
    }
    
    // Update is called once per frame
    void Update()
    {
        
        //Poner la skin (en caso de que haya una)
        if (newSkin)
        {
            SetSkin(skinActual);
            newSkin = false;
        }
        
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
            skinsNames[i] = item;
            i++;
        }
    }


    public void NextSkin()
    {
        index++;
        try
        {
            skinActual = skinsNames[index];
        }
        catch
        {
            skinActual = skinsNames[0];
            index = 0;
        }
        newSkin = true;
    }

    public void PreviousSkin()
    {
        index--;
        try
        {
            skinActual = skinsNames[index];
        }
        catch
        {
            int lastIndex = skinsNames.Length - 1;
            skinActual = skinsNames[lastIndex];
            index = lastIndex;
        }
        newSkin = true;
    }
    
    public void SetSkin(Skin skin)
    {
        //Color por default
        Color colorCorazon = new Color (0.0f, 0.0f, 0.0f, 0.7f); //Negro transparentito
        Color colorLuzAdentro = Color.white;
        Color colorLuzAfuera = Color.white;
        

        switch (skin)
        {
            case Skin.Azul:
                colorCorazon = new Color(0.1368f,0.4284f,0.7075f,0.6823f);
                colorLuzAdentro = new Color(0f,0.7176f,0.7176f,1f);
                colorLuzAfuera = new Color(0.2470f, 0.2039f, 0.7921f);
                break;
            
            case Skin.Rojo:
                colorCorazon = new Color(0.3962f, 0f, 0f, 0.3764f);
                colorLuzAdentro = new Color(0.9921f, 0f, 0.1568f);
                colorLuzAfuera = new Color(0.2470f, 0.2039f, 0.7921f);
                break;
            
            case Skin.Green:
                colorCorazon = Color.green;
                colorLuzAdentro = Color.green;
                colorLuzAfuera = Color.green;
                break;
        }

        luzAfuera.GetComponent<Light>().color = colorLuzAfuera;
        luzAdentro.GetComponent<Light>().color = colorLuzAdentro;
        corazon.GetComponent<Renderer>().material.color = colorCorazon;
    }

}
