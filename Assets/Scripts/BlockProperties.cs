using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class BlockProperties : MonoBehaviour
{
    public bool isBomb;
    public bool isRevelated;
    public int number;

    private void Start()
    {
        GetComponentInChildren<TextMeshPro>().text = number + "";
    }

    private void OnMouseDown()
    {
        Scripter.scripter.DeleteBlock(gameObject.transform.position);
    }

    
}
