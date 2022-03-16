using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public Sprite[] sprites;

    public int limiteCartasGiradas, maximoDeCartasDelMismoTipo;

    public float tiempoDeGiro;

    public GameObject cartaPrefab, contenidoDeCartas;

    [HideInInspector]
    public int numeroDeCartasGiradas => cartasGiradas.Length;

    [HideInInspector]
    public List<Carta> cartasEnTablero;
    
    private Carta[] cartasGiradas;

    private bool estaComparando;

    private List<Sprite> tipos;

    private void Start()
    {
        tipos = sprites.ToList();
        RepartirCartas();
    }

    void RepartirCartas()
    {
        int numeroDeCartas = Random.Range(4, sprites.Length / 2);

        for (int c = 0; c < numeroDeCartas; c++)
        {
            int tipo = Random.Range(0, tipos.Count);
            InstanciarCartas(tipo);
        }
        
        List<Carta> cartas = new List<Carta>(cartasEnTablero);

        for (int c = 0; c < numeroDeCartas * limiteCartasGiradas; c++)
        {
            int index = Random.Range(0, cartas.Count);
            cartas[index].transform.SetParent(contenidoDeCartas.transform);
            cartas.Remove(cartas[index]);
        }
    }

    private void InstanciarCartas(int tipo)
    {
        for (int c = 0; c < limiteCartasGiradas; c++)
        {
            Carta carta = Instantiate(cartaPrefab).GetComponent<Carta>();
            cartasEnTablero.Add(carta);
            Debug.Log($"Tipo: " + tipo + " Tipos: " + tipos.Count);
            carta.AsignarSprite(tipos[tipo], tipo);
        }

        DescartarTipos();
    }

    private void Update()
    {
        cartasGiradas = System.Array.FindAll(cartasEnTablero.ToArray(), carta => carta.estaGirada && !carta.estaLista);

        if (numeroDeCartasGiradas >= limiteCartasGiradas && !estaComparando)
            CompararTipos();     
    }

    void CompararTipos()
    {
        estaComparando = true;
        Carta primeraCarta = cartasGiradas[0];

        for(int c=1; c <cartasGiradas.Length; c++)
        {
            Carta carta = cartasGiradas[c];

            if (carta.tipo == primeraCarta.tipo)
            {
                carta.Descartar();

                if (!primeraCarta.estaLista)
                    primeraCarta.Descartar();
            }
        }

        estaComparando = false;
    }

    void DescartarTipos()
    {
        foreach (Sprite sprite in tipos.ToArray())
        {
            int tipo = System.Array.FindIndex(tipos.ToArray(), item => item.name == sprite.name);
            int cartasDelMismoTipo = System.Array.FindAll(cartasEnTablero.ToArray(), carta => carta.tipo == tipo).Length;
            if (cartasDelMismoTipo >= maximoDeCartasDelMismoTipo)
            {
                tipos.Remove(tipos[tipo]);
            }
        }

    }

    public void ReiniciarJuego()
    {
        SceneManager.LoadScene("Juego");
    }
}
