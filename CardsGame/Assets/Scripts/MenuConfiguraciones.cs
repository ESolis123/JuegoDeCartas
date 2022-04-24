using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuConfiguraciones : MonoBehaviour
{
    public void ApagarMusica() => ManejadorDeMusica.musica = false;

    public void ApagarSonido() => ManejadorDeMusica.efectos = false;
}
