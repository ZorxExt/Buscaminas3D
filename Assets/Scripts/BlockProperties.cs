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
    }
    
    private void OnMouseOver()
    {
        if (Scripter.scripter.lost) return;
        
        if (Input.GetMouseButtonDown(0))
        {
            Scripter.scripter.RecursiveDelete(gameObject.transform.position);
        }

        if (Input.GetMouseButtonDown(1))
        {
            Scripter.scripter.FlagBlock(gameObject.transform.position);
        }
    }
}
