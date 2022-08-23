using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeRotate : MonoBehaviour
{
    public int rotationSpeedX;
    public int rotationSpeedY;
    public int rotationSpeedZ;
    void Start()
    {
        
    }


    void Update()
    {
        gameObject.transform.Rotate(rotationSpeedX * Time.deltaTime *  Vector3.left);
        gameObject.transform.Rotate(rotationSpeedY * Time.deltaTime *  Vector3.down);
        gameObject.transform.Rotate(rotationSpeedZ * Time.deltaTime *  Vector3.back);


    }
}
