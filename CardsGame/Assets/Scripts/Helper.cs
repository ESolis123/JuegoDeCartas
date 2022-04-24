using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helper : MonoBehaviour
{
    public static void NoDestruir (GameObject objeto, string tag)
    {
        var objs = GameObject.FindGameObjectsWithTag(tag);

        if (objs.Length > 1)
        {
            Destroy(objeto.gameObject);
        }

        DontDestroyOnLoad(objeto.gameObject);
    }
}
