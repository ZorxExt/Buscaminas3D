using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cargando : MonoBehaviour
{

    void Start()
    {
        string escenaParaCargar = GestorEscenas.siguienteEscena;
        RenderSettings.skybox.SetColor("_Tint", Color.black);
 
        StartCoroutine(CargarEscena(escenaParaCargar));
    }

    
    
    IEnumerator CargarEscena(string escena)
    {
        yield return new WaitForSeconds(1f);
        
        AsyncOperation operation = SceneManager.LoadSceneAsync(escena);

        while (operation.isDone == false)
        {
            yield return null;
        }
    }
}
