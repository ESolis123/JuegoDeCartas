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
        transform.localScale = Vector3.one;
        gameManager = FindObjectOfType<GameManager>();
        Ocultar();
    }

    private void Update()
    {
        GetComponent<Button>().enabled = gameManager.juegoEnProceso;
    }

    public void AsignarSprite(Sprite sprite, int tipo)
    {
        imagen.sprite = sprite;
        parteDelantera = sprite;
    }

    public void LlamarGiro()
    {
        Girar();
    }

    private void Girar()
    {
        if (!estaLista && !estaGirada && gameManager.numeroDeCartasGiradas < gameManager.limiteCartasGiradas)
        {
            Mostrar();
            PlayClip();
        }
    }

    private void PlayClip()
    {
        AudioSource audioSource = GetComponent<AudioSource>();
        audioSource.loop = false;
        audioSource.playOnAwake = false;
        audioSource.Play();
    }

    public void Ocultar()
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
