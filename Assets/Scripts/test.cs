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
                Scripter.scripter.SpawnBlock(true,new Vector3(i,j,5),1);
            }
        }
        
        for (int j = -5; j < 5; j++)
        {
            for (int i = -5; i < 5; i++)
            {
                Scripter.scripter.SpawnBlock(true,new Vector3(i,j,-5),1);
            }
        }
        for (int j = -5; j < 5; j++)
        {
            for (int i = -4; i < 5; i++)
            {
                Scripter.scripter.SpawnBlock(false,new Vector3(-5,j,i),1);
            }
        }
        for (int j = -5; j < 5; j++)
        {
            for (int i = -4; i < 5; i++)
            {
                Scripter.scripter.SpawnBlock(false,new Vector3(4,j,i),1);
            }
        }
        for (int j = -4; j < 5; j++)
        {
            for (int i = -4; i < 4; i++)
            {
                Scripter.scripter.SpawnBlock(false,new Vector3(i,4,j),1);
            }
        }
        for (int j = -4; j < 5; j++)
        {
            for (int i = -4; i < 4; i++)
            {
                Scripter.scripter.SpawnBlock(false,new Vector3(i,-5,j),1);
            }
        }
        Scripter.scripter.DeleteBlock(new Vector3(4,3,1));
        
        
        Scripter.scripter.DeleteBlock(new Vector3(2,4,1));
        
        Scripter.scripter.DeleteBlock(new Vector3(1,4,1));
        Scripter.scripter.DeleteBlock(new Vector3(2,4,1));

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
