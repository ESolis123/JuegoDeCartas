using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BotonMusica : MonoBehaviour
{
    public Image imagen;
    public Sprite encendido, apagado;

    public void Cambiar()
    {
        ManejadorDeMusica.musica = !ManejadorDeMusica.musica;
        ManejadorDeMusica.efectos = !ManejadorDeMusica.efectos;
    }

    private void VerificarEstadoDeMusica()
    {
        imagen.sprite = ManejadorDeMusica.musica ? encendido : apagado;
    }

    void Update()
    {
        VerificarEstadoDeMusica();
    }
}
