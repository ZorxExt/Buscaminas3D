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

        pointed.GetComponent<BlockProperties>().isFlagged = !pointed.GetComponent<BlockProperties>().isFlagged;
    }
    
    
}