using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
public class MenuParametros : MonoBehaviour
{
    public static int maxCartas = 14, minCartas = 6, tiempo = 60;
    private static bool modificado;
    public Propiedad pCartasMin, pCartasMax, pTiempo;

    void Start()
    {
        GuardarValores();
    }

    private void GuardarValores()
    {
        pCartasMax.value = maxCartas;
        pCartasMin.value = minCartas;
        pTiempo.value = tiempo;
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