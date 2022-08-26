using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject lostUI;
    public GameObject winUI;
    public RawImage temaButton;

    public Texture2D darkThemeButton;
    public Texture2D whiteThemeButton;

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
        lostUI.GetComponent<TextMeshProUGUI>().color = Color.gray;
        if (switcher)
        {
            lostUI.transform.Find("RestartButton").GetComponent<Image>().color = new Color(0.8f, 0.8f, 0.8f);
            lostUI.transform.Find("RestartButton/RestartText").GetComponent<TextMeshProUGUI>().color = Color.black;
            temaButton.texture = darkThemeButton;

        }
        else
        {
            lostUI.transform.Find("RestartButton").GetComponent<Image>().color = new Color(0.2f, 0.2f, 0.2f);
            lostUI.transform.Find("RestartButton/RestartText").GetComponent<TextMeshProUGUI>().color = Color.gray;
            temaButton.texture = whiteThemeButton;
        }
    }
    
    
}
