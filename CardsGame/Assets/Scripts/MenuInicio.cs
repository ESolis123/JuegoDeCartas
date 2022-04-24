using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class MenuInicio : MonoBehaviour
{
    public void Iniciar() => SceneManager.LoadScene("Juego");
    public void Salir() => Application.Quit();
}
