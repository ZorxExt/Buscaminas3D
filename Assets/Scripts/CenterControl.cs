using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CenterControl : MonoBehaviour
{
    private float _verticalInput;
    private float _horizontalInput;
    public Animator animator;
    public float cameraSpeed;

    public void Start()
    {
    }
    
    private void Update()
    {
        _verticalInput = Input.GetAxis("Vertical");
        _horizontalInput = Input.GetAxis("Horizontal");

        //Rotacion en X e Y de la camara
        gameObject.transform.Rotate(cameraSpeed * Time.deltaTime * _horizontalInput *Vector3.down);
        gameObject.transform.Rotate(cameraSpeed * Time.deltaTime * _verticalInput * Vector3.right);
        
        
        //Rotacion en Z de la camara (Se puede mejorar mediante inputs con flots para mas smooth)
        if (Input.GetKey(KeyCode.Q))
        {
            gameObject.transform.Rotate(Time.deltaTime * cameraSpeed * Vector3.back);

        }
        if (Input.GetKey(KeyCode.E))
        {
            gameObject.transform.Rotate(Time.deltaTime * 50 *Vector3.forward);
        }

        if (Input.GetKeyDown(KeyCode.T))
        {
            Renderizado.renderizado.temaOscuro = !Renderizado.renderizado.temaOscuro;
        }
    }
}
