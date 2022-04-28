using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BotonPausa : MonoBehaviour
{
    public Image imagen;
    public Sprite pausar, resumir;
    private GameManager gameManager;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }
    public void Cambiar()
    {
        if(gameManager.juegoTerminado)
            Boton.ReiniciarEscena();

        else
            gameManager.juegoEnProceso = !gameManager.juegoEnProceso;
    }

    private void VerificarEstadoBoton()
    {
        imagen.sprite = gameManager.juegoEnProceso? pausar:resumir;
    }

    void Update()
    {
        VerificarEstadoBoton();
    }
}
