using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using TMPro;
using UnityEditor.IMGUI.Controls;

public class Scripter : MonoBehaviour
{
    public int porcentajeBombas = 50;
    public static Scripter scripter;

    //Prefaps
    public GameObject bomba;
    public GameObject nobomba;
    public GameObject pointer;
    //
    
    private GameObject _pointed;
    private GameObject _newBlock;
    public Dictionary<string, GameObject> blockMap = new Dictionary<string, GameObject>(); 
    



    //Este script es estatico y publico, sus funciones son accesibles desde cualquier parte de la escena.

    void Start()
    {
        scripter = this;
    }


    // Instancia "bomba" o "nobomba" en *coordenadas* y dentro un *numero*
    public void SpawnBlock(bool isBomb, Vector3 coordenadas)
    {
        switch (isBomb)
        {
            case true:
                _newBlock = Instantiate(bomba, coordenadas, Quaternion.identity);
                break;
            case false:
                _newBlock = Instantiate(nobomba, coordenadas, Quaternion.identity);
                break;
        }

        // Diccionario con todos los bloques
        int x = (int)coordenadas.x;
        int y = (int)coordenadas.y;
        int z = (int)coordenadas.z;
        blockMap.Add($"{x},{y},{z}", _newBlock);

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

    public void RecursiveDelete(Vector3 coordenadas)
    {
        DeleteBlock(coordenadas);
        int i = (int)coordenadas.x;
        int j = (int)coordenadas.y;
        int k = (int)coordenadas.z;
        string thisKey = $"{i},{j},{k}";
        GameObject thisBlock = blockMap[thisKey];
        thisBlock.GetComponent<BlockProperties>().isRevealed = true;
        if (thisBlock.GetComponent<BlockProperties>().number == 0)
        {
            for (int x = -1; x <= 1; x++)
            {
                for (int y = -1; y <= 1; y++)
                {
                    for (int z = -1; z <= 1; z++)
                    {
                        string key = $"{x + i},{y + j},{z + k}";
                        if (blockMap.ContainsKey(key) && coordenadas != new Vector3(x+i,y+j,z+k))
                        {
                            GameObject bloqueAdyacente = blockMap[key];
                            if (bloqueAdyacente.GetComponent<BlockProperties>().number != -1
                                && bloqueAdyacente.GetComponent<BlockProperties>().isRevealed == false)
                            {
                                Debug.Log(bloqueAdyacente);
                                RecursiveDelete(bloqueAdyacente.transform.position);

                            }
                            
                        }
                    }
                }
            }
        }
    }
    
    
    

    // o sea cada bloque tiene cierta probabilidad de ser bomba
    // Podríamos hacerlo de otra manera mejor pero esto nos sirve para seguir avanzando pq es cortito
    public bool generarBomba()
    {
        int rnd = UnityEngine.Random.Range(0, 100);
        if (rnd < porcentajeBombas)
        {
            return true;
        }

        return false;
    }
    
    public int CalcularNumero(int i, int j, int k)
    {
        string thisKey = $"{i},{j},{k}";
        GameObject thisBlock = blockMap[thisKey];

        if (thisBlock.name == "Cubo BOMBA(Clone)")
        {
            return -1;
        }
        
        int contador = 0;
        
        for (int x = -1; x <= 1; x++)
        {
            for (int y = -1; y <= 1; y++)
            {
                for (int z = -1; z <= 1; z++)
                {
                    string key = $"{x + i},{y + j},{z + k}";
                    if (blockMap.ContainsKey(key))
                    {
                        GameObject bloqueAdyacente = blockMap[key];
                        if (bloqueAdyacente.name == "Cubo BOMBA(Clone)")
                        {
                            contador++;
                        }
                    }
                }
            }
        }

        return contador;
    }
    
    
}
