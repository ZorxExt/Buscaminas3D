using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class BlockProperties : MonoBehaviour
{
    public bool isBomb;
    public bool isRevealed = false;
    public bool isFlagged;
    public int number;

    private void Start()
    {
        GetComponentInChildren<TextMeshPro>().text = number + "";
        if (isBomb)
        {
            GetComponentInChildren<TextMeshPro>().color = Color.red;   
        }
    }

    private void OnMouseDown()
    {
        Scripter.scripter.RecursiveDelete(gameObject.transform.position);

        if (isBomb)
        {
            Debug.Log("Perdistes wey.");
        }

    }
    

}
