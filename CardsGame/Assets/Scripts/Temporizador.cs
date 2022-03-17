using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Temporizador : MonoBehaviour
{
    public TextMeshProUGUI BotonDeIntentarDeNuevo;
    private float tiempo;
    int minutos, segundos;
    TextMeshProUGUI texto;

    GameManager gameManager;
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        tiempo = gameManager.tiempoTemporizador;
        texto = GetComponent<TextMeshProUGUI>();
    }

    void MostrarTiempo()
    {
        tiempo -= Time.deltaTime;
        minutos = (int) tiempo/60;
        segundos = (int) tiempo%60;
        texto.text = $"{minutos.ToString("00")}:{segundos.ToString("00")}";
    }

    void TerminarJuego()
    {
        if(tiempo <=0)
        {
            gameManager.PresentarBotonDeIntentarDeNuevo("Perdiste \n intenta de nuevo");
            gameManager.juegoEnProceso = false;
        }
    }

    void Update()
    {
        if(gameManager.juegoEnProceso)
        {
            MostrarTiempo();
            TerminarJuego();
        }
    }
}
