using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManejadorDeMusica : MonoBehaviour
{
    public static bool efectos = true, musica = true;
    public Tipo tipo;

    public enum Tipo
    {
        Efectos,
        Musica
    }

    void Start()
    {
        if(tipo.Equals(Tipo.Musica))
            Helper.NoDestruir(gameObject, tipo.ToString());
    }

    void Update()
    {
        Mutear();
    }

    void Mutear()
    {
        var tipos = new Dictionary<Tipo, bool>()
        {
            {Tipo.Efectos, efectos},
            {Tipo.Musica, musica},
        };

        GetComponent<AudioSource>().mute = !tipos[tipo];
    }
}
