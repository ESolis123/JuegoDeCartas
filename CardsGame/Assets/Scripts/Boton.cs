using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Boton : MonoBehaviour
{
    public void CerrarAplicacion() => Application.Quit();

    public void CambiarAEscena(string escena) => SceneManager.LoadScene(escena);

    public void ReiniciarEscena()
    {
        int escenaActual = SceneManager.GetActiveScene().buildIndex;
    }

    public static void ReiniciarEscena(int escena = 0)
    {
        int escenaActual = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(escenaActual);
    }
}
