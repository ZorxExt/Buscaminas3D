using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pointer : MonoBehaviour
{
    private MeshRenderer _mesh;
    public GameObject contact;
    private void OnTriggerStay(Collider other)
    {
        contact = other.gameObject;
    }
}

