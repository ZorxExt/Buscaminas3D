using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GestorEscenas : MonoBehaviour
{
    private static GestorEscenas _instance = null;

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
    }
    
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

