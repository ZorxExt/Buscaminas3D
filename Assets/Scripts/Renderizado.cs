using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Renderizado : MonoBehaviour
{

    public static Renderizado renderizado;
    
    //Diccionario
    public Dictionary<string, GameObject> blockMap = new Dictionary<string, GameObject>();
    
    //Prefaps
    public GameObject cubo;
    public GameObject pointer;

    //Contadores
    public int totalAmountNoBombs;
    public int totalAmountBombs;

    //Variables
    public int porcentajeBombas = 10;
    public bool lost;
    public bool win;
    public bool temaOscuro = true;


    void Start()
    {
        renderizado = this;
    }
    
    //Empezar una capa nueva (o la primera)
    public void CapaNueva(int x1, int x2, int y1, int y2, int z1, int z2)
    {
        BorrarBlockMap();
        CreateTable(x1, x2, y1, y2, z1, z2);
    }

    public void PrimeraCapa()
    {
        //Reset de variables relevntes cuando empezás un juego
        lost = false;
        win = false;
        
        CapaNueva(-5, 4, -5, 4, -5, 4);
    }

    
    // Spawn block in "coordenadas"
    public void SpawnBlock(bool isBomb, Vector3 coordenadas)
    {
        GameObject newBlock;
        
        newBlock = Instantiate(cubo, coordenadas, Quaternion.identity);

        if (!isBomb)
        {
            totalAmountNoBombs++;
        }
        else
        {
            newBlock.GetComponent<BlockProperties>().isBomb = true;
        }

        // Diccionario con todos los bloques
        int x = (int)coordenadas.x;
        int y = (int)coordenadas.y;
        int z = (int)coordenadas.z;
        
        blockMap.Add($"{x},{y},{z}", newBlock);
    }
    
    public void DeleteBlock(Vector3 coordenadas)
    {       
        int x = (int)coordenadas.x;
        int y = (int)coordenadas.y;
        int z = (int)coordenadas.z;
        
        GameObject thisBlock = blockMap[$"{x},{y},{z}"];

        if (thisBlock.GetComponent<BlockProperties>().isFlagged)
        {
            return;
        }
        else if (thisBlock.GetComponent<BlockProperties>().isBomb)
        {
            lost = true;
            UIManager.uiManager.ResetPuntos();
            return;
        }
        
        StartCoroutine(gameObject.GetComponent<PointerMaster>().PointerDelete(coordenadas));

        totalAmountNoBombs--;
        
        if (totalAmountNoBombs <= 0)
        {
            win = true;
            UIManager.uiManager.SumarPuntos(1);
        }
    }
    
    public void ClickDelete(Vector3 coordenadas)
    {
        DeleteBlock(coordenadas);
        
        int i = (int)coordenadas.x;
        int j = (int)coordenadas.y;
        int k = (int)coordenadas.z;
        
        string thisKey = $"{i},{j},{k}";
        
        GameObject thisBlock = blockMap[thisKey];
        
        thisBlock.GetComponent<BlockProperties>().isRevealed = true;
        
        if (thisBlock.GetComponent<BlockProperties>().number == 0)
        {
            for (int x = -1; x <= 1; x++)
            {
                for (int y = -1; y <= 1; y++)
                {
                    for (int z = -1; z <= 1; z++)
                    {
                        string key = $"{x + i},{y + j},{z + k}";
                        
                        if (blockMap.ContainsKey(key) && coordenadas != new Vector3(x+i,y+j,z+k))
                        {
                            GameObject bloqueAdyacente = blockMap[key];
                            
                            if (bloqueAdyacente.GetComponent<BlockProperties>().number != -1
                                && bloqueAdyacente.GetComponent<BlockProperties>().isRevealed == false)
                            {
                                ClickDelete(bloqueAdyacente.transform.position);
                            }
                            
                        }
                    }
                }
            }
        }
    }

    public void ClickFlag(Vector3 coordenadas)
    {
        StartCoroutine(gameObject.GetComponent<PointerMaster>().PointerFlag(coordenadas));
    }
    
    public void RevelarBombas()
    {
        foreach (var item in blockMap.Keys)
        {
            GameObject thisBlock = blockMap[item];
            
            thisBlock.GetComponent<BlockProperties>().isRevealed = true;
        }
    }
    
    public void BorrarBlockMap()
    {
        foreach (var item in blockMap.Keys)
        {
            Destroy(blockMap[item]);
        }
        
        blockMap.Clear();
    }


    
    
    
    
    
    
    
    
    
    
    
    
    // Logica y creacion tablero
    
    
    public bool[] PoblarArray(int length, bool valor)
    {
        bool[] array = new bool[length];
        
        for (int i = 0; i < length; i++)
        {
            array[i] = valor;
        }

        return array;
    }

    public bool[] MezclarArray(bool[] array)
    {
        for (int i = 0; i < array.Length - 1; i++) 
        {
            int rnd = UnityEngine.Random.Range(i, array.Length);
            bool temp = array[rnd];
            array[rnd] = array[i];
            array[i] = temp;
        }
        
        return array;
    }

    public bool[,] Make2DArray(bool[] array1D, int width, int height)
    {
        bool[,] array2D = new bool[width, height];

        int index = 0;
        
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                array2D[i, j] = array1D[index];
                index++;
            }
        }

        return array2D;
    }
    
    
    public bool[,] GenerarCara(int alto, int ancho)
    {

        int bombAmount = porcentajeBombas * alto * ancho / 100;
        totalAmountBombs += bombAmount;
        
        int nobombAmount = (alto * ancho) - bombAmount;
        
        bool[] bombArray = PoblarArray(bombAmount, true);
        bool[] nobombArray = PoblarArray(nobombAmount, false);

        bool[] everythingArray = bombArray.Concat(nobombArray).ToArray();
        bool[] shuffledArray = MezclarArray(everythingArray);

        bool[,] finalArray = Make2DArray(shuffledArray, ancho, alto);
        
        return finalArray;
    }


    public int CalcularNumero(int i, int j, int k)
    {
        string thisKey = $"{i},{j},{k}";
        GameObject thisBlock = blockMap[thisKey];

        if (thisBlock.GetComponent<BlockProperties>().isBomb)
        {
            return -1;
        }

        int contador = 0;

        for (int x = -1; x <= 1; x++)
        {
            for (int y = -1; y <= 1; y++)
            {
                for (int z = -1; z <= 1; z++)
                {

                    if (Math.Abs(x) + Math.Abs(y) + Math.Abs(z) == 3)
                    {
                        continue;
                    }
                    
                    int thisX = (x + i);
                    int thisY = (y + j);
                    int thisZ = (z + k);

                    string key = $"{thisX},{thisY},{thisZ}";
                    
                    if (blockMap.ContainsKey(key))
                    {
                        GameObject bloqueAdyacente = blockMap[key];
                        
                        if (bloqueAdyacente.GetComponent<BlockProperties>().isBomb)
                        {
                            contador++;
                        }
                    }
                }
            }
        }

        return contador;
    }

    public void CreateTable(int x1, int x2, int y1, int y2, int z1, int z2)
    {
        int width = Math.Abs(x1 - x2) + 1;
        int height = Math.Abs(y1 - y2) + 1;
        int depth = Math.Abs(z1 - z2) + 1;

        //PAREDES GRANDES
        
        //Cara 1
        
        bool[,] cara1 = GenerarCara(width, height);
        
        for (int j = y1; j < (y2 + 1) ; j++)
        {
            for (int i = x1; i < (x2 + 1) ; i++)
            {

                bool isBomb = cara1[i - x1, j - y1];
                
                SpawnBlock(isBomb,new Vector3(i, j, z2));
            }
        }
        
        //Cara 2

        bool[,] cara2 = GenerarCara(width, height);

        for (int j = y1; j < (y2 + 1) ; j++)
        {
            for (int i = x1; i < (x2 + 1) ; i++)
            {
                bool isBomb = cara2[i - x1, j - y1];
                
                SpawnBlock(isBomb,new Vector3(i,j, z1));
            }
        } 
        
        //PAREDES CHICAS
        
        //Cara 3
        
        bool[,] cara3 = GenerarCara(depth, height);

        for (int j = y1; j < (y2+1); j++)
        {
            
            for (int k = z1+1; k < z2; k++)
            {
                bool isBomb = cara3[k - (z1 + 1), j - y1];
                
                SpawnBlock(isBomb,new Vector3(x1,j,k));
            }
        }
        
        //Cara 4
        
        bool[,] cara4 = GenerarCara(depth, height);

        for (int j = y1; j < y2+1; j++)
        {
            for (int k = z1+1; k < z2; k++)
            {
                bool isBomb = cara4[j - y1, k - (z1 + 1)];
                
                SpawnBlock(isBomb, new Vector3(x2,j,k));
            }
        }
        
        //TAPAS
        
        //Cara 5
        
        bool[,] cara5 = GenerarCara(width, depth);

        for (int k = z1+1; k < z2; k++)
        {
            for (int i = x1+1; i < x2; i++)
            {
                bool isBomb = cara5[i - (x1 + 1), k - (z1 + 1)];
                
                SpawnBlock(isBomb,new Vector3(i,y2,k));
            }
        }
        
        //Cara 6
        
        bool[,] cara6 = GenerarCara(width, height);

        for (int k = z1+1; k < z2; k++)
        {
            for (int i = x1+1; i < x2; i++)
            {
                bool isBomb = cara6[i - (x1 + 1), k - (z1 + 1)];
                SpawnBlock(isBomb,new Vector3(i,y1,k));
            }
        }
        
        // Acá recorre todos los bloques y les pone su número
        // Tiene q hacerse después de crear los bloques porque sino vas a contar menos minas
        
        
        //PAREDES GRANDES
        
        //Cara 1
        
        for (int j = y1; j < (y2 + 1) ; j++)
        {
            for (int i = x1; i < (x2 + 1); i++)
            {
                string llave = $"{i},{j},{z2}";
                
                GameObject bloque = blockMap[llave];

                int numero = CalcularNumero(i, j, z2);
                
                bloque.GetComponent<BlockProperties>().number = numero;
            }
        }
        
        //Cara 2
        for (int j = y1; j < (y2 + 1); j++)
        {
            for (int i = x1; i < (x2 + 1); i++)
            {
                string llave = $"{i},{j},{z1}";
                GameObject bloque = blockMap[llave];

                int numero = CalcularNumero(i, j, z1);
                bloque.GetComponent<BlockProperties>().number = numero;
            }
        }
        
        //PAREDES CHICAS
        
        //Cara 3
        for (int j = y1; j < (y2+1); j++)
        {
            
            for (int k = z1+1; k < z2; k++)
            {
                string llave = $"{x1},{j},{k}";
                
                GameObject bloque = blockMap[llave];

                int numero = CalcularNumero(x1, j, k);
                bloque.GetComponent<BlockProperties>().number = numero;

            }
        }
        
        //Cara 4
        for (int j = y1; j < y2+1; j++)
        {
            for (int k = z1+1; k < z2; k++)
            {

                string llave = $"{x2},{j},{k}";

                GameObject bloque = blockMap[llave];

                int numero = CalcularNumero(x2, j, k);
                
                bloque.GetComponent<BlockProperties>().number = numero;
            }
        }
        
        //TAPAS
        
        //Cara 5
        
        for (int k = z1+1; k < z2; k++)
        {
            for (int i = x1+1; i < x2; i++)
            {
                string llave = $"{i},{y2},{k}";
                GameObject bloque = blockMap[llave];

                int numero = CalcularNumero(i, y2, k);
                
                bloque.GetComponent<BlockProperties>().number = numero;

            }
        }
        
        //Cara 6
        for (int k = z1+1; k < z2; k++)
        {
            for (int i = x1+1; i < x2; i++)
            {
                string llave = $"{i},{y1},{k}";
                GameObject bloque = blockMap[llave];

                int numero = CalcularNumero(i, y1, k);
                
                bloque.GetComponent<BlockProperties>().number = numero;;

            }
        }
    }
}
