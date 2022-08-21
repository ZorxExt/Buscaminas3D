using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using TMPro;
using UnityEditor.IMGUI.Controls;

public class Scripter : MonoBehaviour
{
    public static Scripter scripter;

    //Prefaps
    public GameObject bomba;
    public GameObject nobomba;
    public GameObject pointer;
    //
    
    private GameObject _pointed;
    private GameObject _newBlock;
    



    //Este script es estatico y publico, sus funciones son accesibles desde cualquier parte de la escena.

    void Start()
    {
        scripter = this;
    }


    // Instancia "bomba" o "nobomba" en *coordenadas* y dentro un *numero*
    public void SpawnBlock(bool isBomb, Vector3 coordenadas, int numero)
    {
        switch (isBomb)
        {
            case true:
                Debug.Log("BOMBA");
                _newBlock = Instantiate(bomba, coordenadas, Quaternion.identity);
                _newBlock.GetComponent<BlockProperties>().number = numero;
                break;
            case false:
                Debug.Log("NOBOMBA");
                _newBlock = Instantiate(nobomba, coordenadas, Quaternion.identity);
                _newBlock.GetComponent<BlockProperties>().number = numero;
                break;
        }
    }


    IEnumerator PointerDelete(Vector3 coordenadas)
    {
        GameObject pointerIt = Instantiate(pointer, coordenadas, Quaternion.identity);
        yield return new WaitForSeconds(0.2f);
        _pointed = pointerIt.GetComponent<Pointer>().contact;
        Destroy(pointerIt);
        _pointed.GetComponent<MeshRenderer>().enabled = false;

    }

    public void DeleteBlock(Vector3 coordenadas)
    {                                   
        StartCoroutine(PointerDelete(coordenadas));
    }

    //Devuelve True si el cubo es una bomba o False en caso contrario
    public void BombOrNot(Vector3 coordenadas)
    {
    }

}