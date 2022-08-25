using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

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

    public void ActivarDarkMode(bool switcher)
    {
        if (switcher)
        {
            lostUI.GetComponent<TextMeshProUGUI>().color = Color.gray;
            lostUI.transform.Find("RestartButton").GetComponent<Image>().color = new Color(0.8f, 0.8f, 0.8f);
            lostUI.transform.Find("RestartButton/RestartText").GetComponent<TextMeshProUGUI>().color = Color.black;

        }
        else
        {
            lostUI.GetComponent<TextMeshProUGUI>().color = Color.black;
            lostUI.transform.Find("RestartButton").GetComponent<Image>().color = new Color(0.2f, 0.2f, 0.2f);
            lostUI.transform.Find("RestartButton/RestartText").GetComponent<TextMeshProUGUI>().color = Color.gray;
        }
    }
    
    
}
