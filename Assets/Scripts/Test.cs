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
        Renderizado.renderizado.CreateTable(-5, 4, -5, 4, -5, 4);
    }

    private void Update()
    {
        UpdatearColores();
    }

    private void UpdatearColores()
    {
        bool temaOscuro = Renderizado.renderizado.temaOscuro;
        Dictionary<string, GameObject> blockMap = Renderizado.renderizado.blockMap;

        foreach (var item in blockMap.Keys)
        {
            GameObject thisBlock = blockMap[item];
            
            thisBlock.GetComponent<MeshRenderer>().material = bloqueActual;

            if (thisBlock.GetComponent<BlockProperties>().isBomb &&
                thisBlock.GetComponent<BlockProperties>().isRevealed)
            {
                thisBlock.GetComponent<MeshRenderer>().material = bloqueActualInvertido;
            }

            if (thisBlock.GetComponent<BlockProperties>().isFlagged)
            {
                thisBlock.GetComponent<MeshRenderer>().material = whiteBlockMaterial;
                thisBlock.GetComponent<MeshRenderer>().material.color = flagColor;
            }

            if (thisBlock.GetComponent<BlockProperties>().isFlagged &&
                !thisBlock.GetComponent<BlockProperties>().isBomb && Renderizado.renderizado.lost)
            {
                thisBlock.GetComponent<MeshRenderer>().material.color = flagColorWrong;
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
