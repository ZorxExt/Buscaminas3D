using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    
    //Materiales
    public Material bloqueActual;
    public Material bloqueActualInvertido;
    public Material darkBlockMaterial;
    public Material whiteBlockMaterial;
    
    //Colores
    public Color skyboxColorClaro = new Color (0.9f, 0.9f, 0.9f);
    public Color skyboxColorOscuro = Color.black;
    public Color bombaExplotada = Color.red;

    //Dependencias

    public UIManager uiManager;
    
    private void Start()
    {
        Renderizado.renderizado.PrimeraCapa();
    }

    private void Update()
    {
        UpdatearColores();
        uiManager.MostrarUIWin(Renderizado.renderizado.win);
        uiManager.MostrarUILost(Renderizado.renderizado.lost);

        if (Renderizado.renderizado.win)
        {
            Renderizado.renderizado.RevelarBombas();
        }
    }

    private void UpdatearColores()
    {
        bool temaOscuro = Renderizado.renderizado.temaOscuro;

        Dictionary<string, GameObject> blockMap = Renderizado.renderizado.blockMap;

        foreach (var item in blockMap.Keys)
        {
            GameObject thisBlock = blockMap[item];
            
            bool isFlagged = thisBlock.GetComponent<BlockProperties>().isFlagged;
            bool isBomb = thisBlock.GetComponent<BlockProperties>().isBomb;
            bool lost = Renderizado.renderizado.lost;
            bool win = Renderizado.renderizado.win;
            
            
            //PLAYING
            thisBlock.GetComponent<MeshRenderer>().material = bloqueActual;

            if (isFlagged)
            {
                thisBlock.GetComponent<MeshRenderer>().material = bloqueActualInvertido;
            }

            //LOST
            if (lost)
            {
                if (isBomb)
                {
                    thisBlock.GetComponent<MeshRenderer>().material = whiteBlockMaterial;
                    thisBlock.GetComponent<MeshRenderer>().material.color = bombaExplotada;
                }

            }
            
            /*
            WIN
             
            (igual esto es temporal porque no se gana, sino que hace una capa nueva, pero está bueno
            tener esto a mano para cuando queramos animar la aparición de la capa nueva)
            
            Lo que hace ahora mismo esta parte del script es mostrar todas las bombas una vez no te quedan más,
            así hace el buscaminas real
            
            Nosotros podemos hacer que cuando ganás, en esa capa, muestra todas las bombas, hace una
            animación godita y luego hace una capa nueva con la función Renderizado.renderizado.CapaNueva
            */
            
            if (win)
            {
                if (isFlagged || isBomb)
                {
                    thisBlock.GetComponent<MeshRenderer>().material = bloqueActualInvertido;
                }
            }
        }

        if (temaOscuro)
        {
            bloqueActual = whiteBlockMaterial;
            bloqueActualInvertido = darkBlockMaterial;

            uiManager.ActivarDarkMode(true);
        }
        else
        {
            bloqueActual = darkBlockMaterial;
            bloqueActualInvertido = whiteBlockMaterial;

            uiManager.ActivarDarkMode(false);
        }
    }
}
