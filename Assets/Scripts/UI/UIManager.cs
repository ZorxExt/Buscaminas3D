using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Slider = UnityEngine.UIElements.Slider;

public class UIManager : MonoBehaviour
{
    public GameObject lostUI;
    public GameObject winUI;
    public RawImage temaButton;
    public TextMeshProUGUI scoreText;
    public int puntaje;
    public Animator menuAnimator;
    public GameObject panelControls;
    public Animator panelAnimator;

    public Texture2D darkThemeButton;
    public Texture2D whiteThemeButton;


    public static UIManager uiManager;

    private void Start()
    {
        uiManager = this;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            menuAnimator.SetTrigger("AbrirCerrar");
        }
    }

    public void SumarPuntos(int puntos)
    {
        puntaje = puntaje + puntos;
    }

    public void ResetPuntos()
    {
        puntaje = 0;
    }
    

    public void MostrarUILost(bool switcher)
    {
        lostUI.SetActive(switcher);
    }
    
    public void MostrarUIWin(bool switcher)
    {
        scoreText.text = ""+puntaje;
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
