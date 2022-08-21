using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CenterControl : MonoBehaviour
{
    private float _verticalInput;
    private float _horizontalInput;

    public float cameraSpeed;
    
    void Update()
    {
        _verticalInput = Input.GetAxis("Vertical");
        _horizontalInput = Input.GetAxis("Horizontal");

        //Rotacion en X e Y de la camara
        gameObject.transform.Rotate(Vector3.down * _horizontalInput * Time.deltaTime * cameraSpeed);
        gameObject.transform.Rotate(Vector3.right * _verticalInput * Time.deltaTime * cameraSpeed);
        
        
        //Rotacion en Z de la camara (Se puede mejorar mediante inputs con flots para mas smooth)
        if (Input.GetKey(KeyCode.Q))
        {
            gameObject.transform.Rotate(Vector3.back * Time.deltaTime * cameraSpeed);
        }
        if (Input.GetKey(KeyCode.E))
        {
            gameObject.transform.Rotate(Vector3.forward * Time.deltaTime * 50);
        }
    }
}
