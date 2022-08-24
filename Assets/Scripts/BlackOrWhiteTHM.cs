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
        
        
        
        foreach (var item in Scripter.scripter.blockMap.Keys)
        {
            _thisBlock = Scripter.scripter.blockMap[item];

            if (_thisBlock.GetComponent<MeshRenderer>().material == whiteBlockMaterial)
            {
                Debug.Log("GAY");
                _thisBlock.GetComponent<MeshRenderer>().material = darkBlockMaterial;
            }
            else
            {
                _thisBlock.GetComponent<MeshRenderer>().material = whiteBlockMaterial;
            }
        }
    }
}
