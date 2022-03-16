using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Carta : MonoBehaviour
{
    [HideInInspector]
    public int tipo;

    [HideInInspector]
    public bool estaGirada, estaLista;

    GameManager gameManager;
    Image imagen;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        imagen = GetComponent<Image>();
        Ocultar();
    }

    public void AsignarSprite(Sprite sprite, int tipo)
    {
        this.tipo = tipo;
        GetComponent<Image>().sprite = sprite;
    }

    public void LlamarGiro()
    {
        StartCoroutine(Girar());
    }

    private IEnumerator Girar()
    {
        if (!estaLista && !estaGirada && gameManager.numeroDeCartasGiradas < gameManager.limiteCartasGiradas)
        {
            Mostrar();
            yield return new WaitForSeconds(gameManager.tiempoDeGiro);
            
            if(!estaLista)
                Ocultar();
        }
    }

    private void Ocultar()
    {
        estaGirada = false;
        imagen.color = Color.black;
    }

    private void Mostrar()
    {
        estaGirada = true;
        imagen.color = Color.white;
    }

    public void Descartar()
    {
        estaLista = true;
        imagen.color = Color.red;
    }
}
