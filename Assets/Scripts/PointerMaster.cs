using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PointerMaster : MonoBehaviour
{

    
    public IEnumerator PointerDelete(Vector3 coordenadas)
    {
  

        GameObject pointerIt = Instantiate(gameObject.GetComponent<Renderizado>().pointer, coordenadas, Quaternion.identity);
        yield return new WaitForSeconds(0.2f);
        GameObject pointed = pointerIt.GetComponent<Pointer>().contact;

        Destroy(pointerIt);

        pointed.GetComponent<MeshRenderer>().enabled = false;
        pointed.GetComponent<Collider>().enabled = false;

        gameObject.GetComponent<Renderizado>().totalAmountNoBombs--;
        

        if (pointed.GetComponent<BlockProperties>().number == 0)
        {
            pointed.GetComponentInChildren<TextMeshPro>().text = "";
            
        }
    }
    public IEnumerator PointerFlag(Vector3 coordenadas)
    {
        GameObject pointerIt = Instantiate(gameObject.GetComponent<Renderizado>().pointer, coordenadas, Quaternion.identity);
        
        yield return new WaitForSeconds(0.2f);
        
        GameObject pointed = pointerIt.GetComponent<Pointer>().contact;
        
        Destroy(pointerIt);

        bool isFlagged = pointed.GetComponent<BlockProperties>().isFlagged;

        if (isFlagged)
        {
            pointed.GetComponent<MeshRenderer>().material = Renderizado.renderizado.bloqueActual;
            pointed.GetComponent<MeshRenderer>().material.color = Color.white;
        }
        else
        {
            pointed.GetComponent<MeshRenderer>().material = Renderizado.renderizado.whiteBlockMaterial;
            pointed.GetComponent<MeshRenderer>().material.color = Renderizado.renderizado.flagColor;
        }
        
        pointed.GetComponent<BlockProperties>().isFlagged = !isFlagged;
    }
    
    
}