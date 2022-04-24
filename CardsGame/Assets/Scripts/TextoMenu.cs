using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
public class TextoMenu : MonoBehaviour
{
    Color colorPrevio;
    TextMeshProUGUI componenteTexto;

    void Start()
    {
       componenteTexto = GetComponentInChildren<TextMeshProUGUI>();
    }

    public void OnMouseOver()
    {
        Debug.Log($"Onselect Nombre: {name}");
        colorPrevio = componenteTexto.color;
        componenteTexto.color = Color.yellow;
    }

    public void OnMouseExit()
    {
        Debug.Log($"OnDeselect Nombre: {name}");
        componenteTexto.color = colorPrevio;
    }
}
