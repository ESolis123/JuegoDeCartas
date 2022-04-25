using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class MenuParametros : MonoBehaviour
{
    public static int maxCartas = 16, minCartas = 8, tiempo = 30;
    public Slider cartasMinSlider, cartasMaxSlider, tiempoSlider;
    public TextMeshProUGUI actualMaxCartas, actualMinCartas, actualTiempo;
    void Start()
    {
        cartasMaxSlider.value = maxCartas;
        cartasMinSlider.value = minCartas;
        tiempoSlider.value = tiempo;
    }
    public void CambiarMaximoDeCartas() => maxCartas = (int) cartasMaxSlider.value;
    public void CambiarMinimoDeCartas() => minCartas = (int) cartasMinSlider.value;
    public void CambiarTiempo() => tiempo = (int) tiempoSlider.value;
    private void ActualizarValores()
    {
        actualTiempo.text = tiempo.ToString();
        actualMaxCartas.text = maxCartas.ToString();
        actualMinCartas.text = minCartas.ToString();
    }
    private void Update() => ActualizarValores();
}
