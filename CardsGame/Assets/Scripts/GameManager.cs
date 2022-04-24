using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using UnityEngine.SceneManagement;
using TMPro;
public class GameManager : MonoBehaviour
{
    public Sprite[] sprites;

    public int tiempoTemporizador, limiteCartasGiradas, maximoDeCartasDelMismoTipo, cartasRepartidas_X_2;

    public float tiempoDeGiro;

    public GameObject cartaPrefab, contenidoDeCartas;

    public TextMeshProUGUI BotonDeIntentarDeNuevo;

    [HideInInspector]
    public int numeroDeCartasGiradas => cartasGiradas.Length;

    [HideInInspector]
    public List<Carta> cartasEnTablero;

    [HideInInspector]
    public bool juegoEnProceso;

    private List<string> tiposEliminados = new List<string>();

    private Carta[] cartasGiradas;

    private bool estaComparando;

    private List<Sprite> tipos;

    private void Start()
    {
        juegoEnProceso = true;
        tipos = sprites.ToList();
        RepartirCartas();
    }

    void RepartirCartas()
    {
        int numeroDeCartas = Random.Range(4, cartasRepartidas_X_2);

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
            carta.AsignarSprite(tipos[tipo], tipo);
            DescartarTipos();
        }
    }

    private void Update()
    {
        cartasGiradas = System.Array.FindAll(cartasEnTablero.ToArray(), carta => carta.estaGirada && !carta.estaLista);

        if (numeroDeCartasGiradas >= limiteCartasGiradas && !estaComparando)
            StartCoroutine(CompararTipos());

        VerificarSiGano();
    }

    IEnumerator CompararTipos()
    {
        estaComparando = true;
        Carta primeraCarta = cartasGiradas[0];

        for(int c=1; c <cartasGiradas.Length; c++)
        {
            Carta carta = cartasGiradas[c];

            if (carta.personaje == primeraCarta.personaje)
            {
                carta.Descartar();

                if (!primeraCarta.estaLista)
                    primeraCarta.Descartar();
            }

            else
            {
                yield return new WaitForSeconds(0.5f);
                carta.Ocultar();
                primeraCarta.Ocultar();
            }
        }

        estaComparando = false;
    }

    void DescartarTipos()
    {
        foreach (Sprite sprite in tipos.ToArray())
        {
            int cartasDelMismoTipo = System.Array.FindAll(
                cartasEnTablero.ToArray(), carta => carta.personaje == sprite.name && !EsUnTipoEliminado(sprite.name)
            ).Length;

            if (cartasDelMismoTipo >= maximoDeCartasDelMismoTipo)
            {
                tipos.Remove(sprite);
                tiposEliminados.Add(sprite.name);
            }
        }
    }

    bool EsUnTipoEliminado(string tipo)
    {
        return System.Array.Exists(tiposEliminados.ToArray(), tipoEliminado => tipoEliminado == tipo);
    }

    public void ReiniciarJuego()
    {
        SceneManager.LoadScene("Juego");
    }

    void VerificarSiGano()
    {
        if(juegoEnProceso)
        {
            int cartasListas = System.Array.FindAll(cartasEnTablero.ToArray(), carta => carta.estaLista).Length;
            bool gano = cartasListas >= cartasEnTablero.Count;
            juegoEnProceso = !gano;

            if(gano)
                PresentarBotonDeIntentarDeNuevo("¡Ganaste! \n Juega otra vez");
        }
    }

    public void PresentarBotonDeIntentarDeNuevo(string text)
    {
        DestruirCartas();
        BotonDeIntentarDeNuevo.text = text;
        BotonDeIntentarDeNuevo.gameObject.SetActive(true);
    }

    private void DestruirCartas()
    {
        foreach(Transform carta in contenidoDeCartas.transform)
        {
            Destroy(carta.gameObject);
        }
    }
}
