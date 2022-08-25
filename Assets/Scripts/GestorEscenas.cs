using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GestorEscenas : MonoBehaviour
{

    public void CambiarEscena(string escena)
    {
        if (escena == "salir")
        {
            Application.Quit();
        }
        else
        {
            SceneManager.LoadScene(escena);
            Renderizado.renderizado.BorrarBlockMap();
        }
    }
}

