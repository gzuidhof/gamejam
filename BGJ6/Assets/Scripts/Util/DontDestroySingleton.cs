using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DontDestroySingleton : MonoBehaviour
{

    private static List<string> list = new List<string>();

    void Awake()
    {
        if (list.Contains(gameObject.name))
        {
            DestroyImmediate(gameObject);
        }
        else
        {
            list.Add(gameObject.name);
            DontDestroyOnLoad(gameObject);
        }
    }
}
