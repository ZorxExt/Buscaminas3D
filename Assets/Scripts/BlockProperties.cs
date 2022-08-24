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
        if (Renderizado.renderizado.lost)
        {
            return;
        }

        Vector3 position = gameObject.transform.position;
        
        if (Input.GetMouseButtonDown(0))
        {
            Renderizado.renderizado.ClickDelete(position);
            
            if (isBomb)
            {
                Renderizado.renderizado.lost = true;
                _blockSound.PlayOneShot(loseSound);
                Renderizado.renderizado.RevelarBombas();
            }
            else
            {
                _blockSound.PlayOneShot(deleteBlockSound);
            }

        }

        if (Input.GetMouseButtonDown(1))
        {
            Renderizado.renderizado.ClickFlag(position);
        }
    }
}
