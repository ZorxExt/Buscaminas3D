using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Scripter : MonoBehaviour
{
    public static Scripter scripter;
  
    //Prefaps
    public GameObject bomba;
    public GameObject nobomba;
    public GameObject pointer;
    //
    private GameObject _pointerIt;
    public GameObject pointed;
    private GameObject _newBlock;
    

    
    
    //Este script es estatico y publico, sus funciones son accesibles desde cualquier parte de la escena.
   
    void Start()
    {
        scripter = this;
    }
    

    // Instancia "bomba" o "nobomba" en *coordenadas* y dentro un *numero*
    public void SpawnBlock(string bombaOnobomba, Vector3 coordenadas, int numero)
    {
        switch (bombaOnobomba)
        {
            case "bomba":
                Debug.Log("BOMBA");
                _newBlock = Instantiate(bomba, coordenadas, Quaternion.identity);
                _newBlock.GetComponentInChildren<TextMeshPro>().text = numero + "";
                break;
            case "nobomba":
                Debug.Log("NOBOMBA");
                _newBlock = Instantiate(nobomba, coordenadas, Quaternion.identity);
                _newBlock.GetComponentInChildren<TextMeshPro>().text = numero + "";
                break;
            default:
                Debug.Log("ERROR: TIPO ERRADO");
                break;
        }
    }
    

    public void PointerGetComponent()
    {
        pointed = _pointerIt.GetComponent<Pointer>().contact;
    }
    
    public void DeleteBlock(Vector3 coordenadas)
    {
        _pointerIt = Instantiate(pointer, coordenadas,Quaternion.identity);
        Invoke(nameof(PointerGetComponent),0.1f);
        Destroy(pointed);

    }
    
    //Devuelve True si el cubo es una bomba o False en caso contrario
    public void BombOrNot(Vector3 coordenadas)
    {
    }
}


