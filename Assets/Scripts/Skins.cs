using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Skins : MonoBehaviour
{
    public enum Skin
    {
        Azul,
        Rojo,
        Naranja
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
            SetSkin();
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
    public void SetSkin()
    {
        /*Color colorCorazon = new Color (0.0f, 0.0f, 0.0f, 0.7f);
        Color colorLuzAdentro = new Color (1.0f, 1.0f, 1.0f);
        Color colorLuzAfuera = new Color (1.0f, 1.0f, 1.0f);/*
            
        /*switch(color)
        {
            case "red":
                colorCorazon = new Color(0.7f, 0.0f, 0.1f, 0.7f);
                colorLuzAdentro = new Color(1.0f, 0.0f, 0.0f);
                break;
                    
            case "azul":
                colorCorazon = new Color (0.1f, 0.3f, 0.6f, 0.7f);
                colorLuzAdentro = new Color (0.0f, 0.0f, 1.0f);
                break;

        }
                
        luzDeAdentro.GetComponent<Light>().color = colorLuzAdentro;
        corazon.GetComponent<Renderer>().material.color = colorCorazon;*/
            
    }

}
