using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {
        for (int j = -5; j < 5; j++)
        {
            for (int i = -5; i < 5; i++)
            {
                bool isBomb = Scripter.scripter.generarBomba();
                Scripter.scripter.SpawnBlock(isBomb,new Vector3(i, j, 5));

            }
        }
        
        for (int j = -5; j < 5; j++)
        {
            for (int i = -5; i < 5; i++)
            {
                bool isBomb = Scripter.scripter.generarBomba();
                Scripter.scripter.SpawnBlock(isBomb,new Vector3(i,j,-5));

            }
        }
        

        for (int j = -5; j < 5; j++)
        {
            
            for (int i = -4; i < 5; i++)
            {
                bool isBomb = Scripter.scripter.generarBomba();
                Scripter.scripter.SpawnBlock(isBomb,new Vector3(-5,j,i));

            }
        }
        

        for (int j = -5; j < 5; j++)
        {
            for (int i = -4; i < 5; i++)
            {
                bool isBomb = Scripter.scripter.generarBomba();
                Scripter.scripter.SpawnBlock(isBomb, new Vector3(4,j,i));

            }
        }

        for (int j = -4; j < 5; j++)
        {
            for (int i = -4; i < 4; i++)
            {
                bool isBomb = Scripter.scripter.generarBomba();
                Scripter.scripter.SpawnBlock(isBomb,new Vector3(i,4,j));

            }
        }
        

        for (int j = -4; j < 5; j++)
        {
            for (int i = -4; i < 4; i++)
            {
                bool isBomb = Scripter.scripter.generarBomba();
                Scripter.scripter.SpawnBlock(isBomb,new Vector3(i,-5,j));

            }
        }

        // Acá recorre todos los bloques y les pone su número
        // Tiene q hacerse después de crear los bloques porque sino vas a contar menos minas
        
        for (int j = -5; j < 5; j++)
        {
            for (int i = -5; i < 5; i++)
            {
                string llave = $"{i},{j},5";
                GameObject bloque = Scripter.scripter.blockMap[llave];
                int numero = Scripter.scripter.CalcularNumero(i, j, 5);
                bloque.GetComponent<BlockProperties>().number = numero;
            }
        }
        
        for (int j = -5; j < 5; j++)
        {
            for (int i = -5; i < 5; i++)
            {
                string llave = $"{i},{j},-5";
                GameObject bloque = Scripter.scripter.blockMap[llave];
                int numero = Scripter.scripter.CalcularNumero(i, j, -5);
                bloque.GetComponent<BlockProperties>().number = numero;
            }
        }
        

        for (int j = -5; j < 5; j++)
        {
            
            for (int i = -4; i < 5; i++)
            {
                string llave = $"-5,{j},{i}";
                GameObject bloque = Scripter.scripter.blockMap[llave];
                int numero = Scripter.scripter.CalcularNumero(-5, j, i);
                bloque.GetComponent<BlockProperties>().number = numero;

            }
        }
        

        for (int j = -5; j < 5; j++)
        {
            for (int i = -4; i < 5; i++)
            {
                string llave = $"4,{j},{i}";
                GameObject bloque = Scripter.scripter.blockMap[llave];
                int numero = Scripter.scripter.CalcularNumero(4, j, i);
                bloque.GetComponent<BlockProperties>().number = numero;
            }
        }

        for (int j = -4; j < 5; j++)
        {
            for (int i = -4; i < 4; i++)
            {
                string llave = $"{i},4,{j}";
                GameObject bloque = Scripter.scripter.blockMap[llave];
                int numero = Scripter.scripter.CalcularNumero(i, 4, j);
                bloque.GetComponent<BlockProperties>().number = numero;

            }
        }
        

        for (int j = -4; j < 5; j++)
        {
            for (int i = -4; i < 4; i++)
            {
                string llave = $"{i},-5,{j}";
                GameObject bloque = Scripter.scripter.blockMap[llave];
                int numero = Scripter.scripter.CalcularNumero(i, -5, j);
                bloque.GetComponent<BlockProperties>().number = numero;
            }
        }
        
        /*Scripter.scripter.DeleteBlock(new Vector3(4,3,1));
        
        
        Scripter.scripter.DeleteBlock(new Vector3(2,4,1));
        
        Scripter.scripter.DeleteBlock(new Vector3(1,4,1));
        Scripter.scripter.DeleteBlock(new Vector3(2,4,1));*/
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
