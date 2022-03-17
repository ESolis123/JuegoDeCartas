using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Carta : MonoBehaviour
{
    public Image imagen;
    public Sprite parteTrasera;

    public string personaje => parteDelantera.name;

    [HideInInspector]
    public bool estaGirada, estaLista;
    GameManager gameManager;
    private Sprite parteDelantera;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        Ocultar();
    }

    public void AsignarSprite(Sprite sprite, int tipo)
    {
        imagen.sprite = sprite;
        parteDelantera = sprite;
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
            PlayClip();
            yield return new WaitForSeconds(gameManager.tiempoDeGiro);

            if(!estaLista)
                Ocultar();
        }
    }

    private void PlayClip()
    {
        AudioSource audioSource = GetComponent<AudioSource>();
        audioSource.loop = false;
        audioSource.playOnAwake = false;
        audioSource.Play();
    }

    private void Ocultar()
    {
        estaGirada = false;
        imagen.sprite = parteTrasera;
    }

    private void Mostrar()
    {
        estaGirada = true;
        imagen.sprite = parteDelantera;
    }

    public void Descartar()
    {
        estaLista = true;
    }
}
