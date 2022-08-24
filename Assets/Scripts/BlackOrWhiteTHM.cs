using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackOrWhiteTHM : MonoBehaviour
{
    public void ChangeTheme()
    {
        Renderizado.renderizado.temaOscuro = !Renderizado.renderizado.temaOscuro;
    }
}

