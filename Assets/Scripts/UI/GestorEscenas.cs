using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GestorEscenas : MonoBehaviour
{


    public static string siguienteEscena;
     
    private void Start()
    {
        RenderSettings.skybox.SetColor("_Tint", Color.black);
    }

    public void CambiarEscena(string escena)
    {

        if (escena == "Salir")
        {
            Application.Quit();
        }
        
        siguienteEscena = escena;

        SceneManager.LoadScene("PantallaDeCarga");

    }
}

