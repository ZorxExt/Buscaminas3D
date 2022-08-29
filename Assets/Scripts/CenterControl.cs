using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CenterControl : MonoBehaviour
{
    private float _verticalInput;
    private float _horizontalInput;
    private float _profundiadInput;
    public Animator temaAnimator;
    public float cameraSpeed;

    public void Start()
    {
    }
    
    private void Update()
    {
        _verticalInput = Input.GetAxis("Vertical");
        _horizontalInput = Input.GetAxis("Horizontal");
        _profundiadInput = Input.GetAxis("Rotate");
        //Rotacion en X e Y de la camara
        gameObject.transform.Rotate(cameraSpeed * Time.deltaTime * _horizontalInput *Vector3.down);
        gameObject.transform.Rotate(cameraSpeed * Time.deltaTime * _verticalInput * Vector3.right);
        gameObject.transform.Rotate(cameraSpeed * Time.deltaTime * _profundiadInput * Vector3.back);

        if (Input.GetKeyDown(KeyCode.T))
        {
            temaAnimator.SetTrigger("CambiarTema");
            Renderizado.renderizado.temaOscuro = !Renderizado.renderizado.temaOscuro;
        }
    }
}
