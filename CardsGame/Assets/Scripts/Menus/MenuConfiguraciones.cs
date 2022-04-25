using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MenuConfiguraciones : MonoBehaviour
{
    public TextMeshProUGUI botonApagarMusica, botonApagarEfectos;

    void Update()
    {
        botonApagarMusica.text = ManejadorDeMusica.musica ? "Apagar musica" : "Encender musica";
        botonApagarEfectos.text = ManejadorDeMusica.efectos ? "Apagar efectos" : "Encender efectos";
    }

    public void ApagarMusica() => ManejadorDeMusica.musica = !ManejadorDeMusica.musica;

    public void ApagarSonido() => ManejadorDeMusica.efectos = !ManejadorDeMusica.efectos;
}
