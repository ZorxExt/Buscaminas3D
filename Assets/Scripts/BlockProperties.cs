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
    public AudioClip deleteBlockSound;
    public AudioClip loseSound;
    private AudioSource _blockSound;

    private void Start()
    {
        GetComponentInChildren<TextMeshPro>().text = number + "";
        _blockSound = gameObject.GetComponent<AudioSource>();

    }
    
    private void OnMouseOver()
    {
        if (Scripter.scripter.lost)
        {
            return;
        }

        Vector3 position = gameObject.transform.position;
        
        if (Input.GetMouseButtonDown(0))
        {
            Scripter.scripter.RecursiveDelete(position);
            
            if (isBomb)
            {
                Scripter.scripter.lost = true;
                _blockSound.PlayOneShot(loseSound);
                Scripter.scripter.RevelarBombas();
            }
            else
            {
                _blockSound.PlayOneShot(deleteBlockSound);
            }

            //gameObject.GetComponent<Renderer>().material.color = Color.green;

        }

        if (Input.GetMouseButtonDown(1))
        {
            Scripter.scripter.FlagBlock(position);
        }
    }
}
