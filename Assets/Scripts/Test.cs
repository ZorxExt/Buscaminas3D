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
    public Color flagColor = Color.gray; //Tanto para el modo claro como para el modo oscuro
    public Color flagColorWrong = Color.red; //Tanto para el modo claro como para el modo oscuro
    public Color skyboxColorClaro = new Color (0.9f, 0.9f, 0.9f);
    public Color skyboxColorOscuro = Color.black;

    // Start is called before the first frame update
    
    private void Start()
    {
        Renderizado.renderizado.CapaNueva(-5, 4, -5, 4, -5, 4);
    }

    private void Update()
    {
        UpdatearColores();

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
            bool isRevealed = thisBlock.GetComponent<BlockProperties>().isRevealed;
            bool lost = Renderizado.renderizado.lost;
            bool win = Renderizado.renderizado.win;
            
            
            //PLAYING
            thisBlock.GetComponent<MeshRenderer>().material = bloqueActual;

            if (isFlagged)
            {
                thisBlock.GetComponent<MeshRenderer>().material = whiteBlockMaterial;
                thisBlock.GetComponent<MeshRenderer>().material.color = flagColor;
            }

            //LOST
            if (lost)
            {
                if (isFlagged && !isBomb)
                {
                    thisBlock.GetComponent<MeshRenderer>().material.color = flagColorWrong;
                }

                if (isBomb)
                {
                    thisBlock.GetComponent<MeshRenderer>().material = bloqueActualInvertido;
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
            RenderSettings.skybox.SetColor("_Tint", skyboxColorOscuro);
        }
        else
        {
            bloqueActual = darkBlockMaterial;
            bloqueActualInvertido = whiteBlockMaterial;
            RenderSettings.skybox.SetColor("_Tint", skyboxColorClaro);
        }
    }
}
