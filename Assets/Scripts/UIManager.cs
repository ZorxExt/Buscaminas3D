using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject lostUI;
    public GameObject winUI;

    public void MostrarUILost(bool switcher)
    {
        
        lostUI.SetActive(switcher);
    }
    
    public void MostrarUIWin(bool switcher)
    {
        
        winUI.SetActive(switcher);
    }
}
