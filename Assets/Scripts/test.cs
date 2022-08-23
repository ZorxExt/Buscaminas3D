using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{


    // Start is called before the first frame update
    
    private void Start()
    {
        
        Scripter.scripter.CreateTable(-5,4,-5,4,-5,4);
        //Scripter.scripter.CreateTable(15,30,15,30,15,30);
        
    }

}
