using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackOrWhiteTHM : MonoBehaviour
{

    private GameObject _thisBlock;
    private bool _isBlack = true;
    
    public void ChangeTheme()
    {
        Material darkBlockMaterial = Renderizado.renderizado.darkBlockMaterial;
        Material whiteBlockMaterial = Renderizado.renderizado.whiteBlockMaterial;

        if (!_isBlack)
        {
            Renderizado.renderizado.bloqueActual = whiteBlockMaterial;
            Renderizado.renderizado.bloqueActualInvertido = darkBlockMaterial;

        }
        else
        {
            Renderizado.renderizado.bloqueActual = darkBlockMaterial;
            Renderizado.renderizado.bloqueActualInvertido = whiteBlockMaterial;
        }
        
        foreach (var item in Renderizado.renderizado.blockMap.Keys)
        {
            _thisBlock = Renderizado.renderizado.blockMap[item];

            if (_thisBlock.GetComponent<BlockProperties>().isFlagged)
            {
                continue;
            }
            if (_thisBlock.GetComponent<BlockProperties>().isBomb && _thisBlock.GetComponent<BlockProperties>().isRevealed)
            {
                _thisBlock.GetComponent<MeshRenderer>().material = Renderizado.renderizado.bloqueActualInvertido;
            }
            else
            {
                _thisBlock.GetComponent<MeshRenderer>().material = Renderizado.renderizado.bloqueActual;
            }
        }

        _isBlack = !_isBlack;

/*

        if (!_isBlack)
        {
            foreach (var item in Scripter.scripter.blockMap.Keys)
            {
                _thisBlock = Scripter.scripter.blockMap[item];
                _thisBlock.GetComponent<MeshRenderer>().material = darkBlockMaterial;
                
                if (_thisBlock.GetComponent<BlockProperties>().isFlagged)
                {
                    _thisBlock.GetComponent<MeshRenderer>().material = whiteBlockMaterial;
                }

                
                
            }

            _isBlack = true;
        }
    
    */
    }
}

