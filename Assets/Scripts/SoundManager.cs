using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    private AudioSource _deleteBlockSound;
    // Start is called before the first frame update
    void Start()
    {
        _deleteBlockSound = gameObject.GetComponent<AudioSource>();
    }

    
    void Update()
    {
        
    }
}
