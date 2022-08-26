using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GestorEscenas : MonoBehaviour
{
    private void Start()
    {
        RenderSettings.skybox.SetColor("_Tint", Color.black);
    }

    public void CambiarEscena(string escena)
    {
        if (escena == "salir")
        {
            Application.Quit();
        }
        else if (escena == "Juego")
        {
            SceneManager.LoadScene(escena);
        }
        else
        {
            SceneManager.LoadScene(escena);
            Renderizado.renderizado.BorrarBlockMap();
        }
    }
}

