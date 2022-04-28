using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
public class MenuParametros : MonoBehaviour
{
    public static int maxCartas = 0, minCartas = 0, tiempo = 0;
    public Propiedad pCartasMin, pCartasMax, pTiempo;

    void Start()
    {
        IniciarValores();
    }

    private void IniciarValores()
    {
        if(maxCartas == 0 && minCartas ==0 && tiempo ==0)
        {
            maxCartas = (int) pCartasMax.value;
            minCartas = (int) pCartasMin.value;
            tiempo =  (int) pTiempo.value;
        }
    }

    public void CambiarMaximoDeCartas() => maxCartas = (int) pCartasMax.value;
    public void CambiarMinimoDeCartas() => minCartas = (int) pCartasMin.value;
    public void CambiarTiempo() => tiempo = (int) pTiempo.value;

    private void Update()
    {
        pCartasMax.Actualizar();
        pCartasMin.Actualizar();
        pTiempo.Actualizar();
    }
}

[Serializable]
public struct Propiedad
{
    public Slider slider;
    public TextMeshProUGUI label;
    public bool soloPares;
    public int value
    {
        get => (int) slider.value;
        set => slider.value = value;
    }

    public string texto
    {
        set => label.text = value;
    }

    public void Actualizar()
    {
        if(soloPares)
            ActualizarTexto(0);
        else
            ActualizarTexto();
    }

    private void ActualizarTexto(int op)
    {
        if (value % 2 != 0)
            value--;
        else
            ActualizarTexto();

        if (value < 0)
            value = 0;
    }

    private void ActualizarTexto() => texto = value.ToString();
}