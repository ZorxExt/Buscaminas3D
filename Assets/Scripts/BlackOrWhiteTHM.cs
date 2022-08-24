using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackOrWhiteTHM : MonoBehaviour
{
    public Material darkBlockMaterial;
    public Material whiteBlockMaterial;

    private GameObject _thisBlock;
    private bool _isBlack;

    public void ChangeTheme()
    {
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

