using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackOrWhiteTHM : MonoBehaviour
{
    public Animator temaAnimator;

    public void ChangeTheme()
    {
        temaAnimator.SetTrigger("CambiarTema");
        Renderizado.renderizado.temaOscuro = !Renderizado.renderizado.temaOscuro;
    }
}
