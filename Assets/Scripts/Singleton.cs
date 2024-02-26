using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour
{
    public static T instance;

    void Awake()
    {
        if(instance == null) 
        {
            instance = GetComponent<T>();
            DontDestroyOnLoad(gameObject);
        }
        else 
        {
            DestroyImmediate(gameObject);
        }
    }
}
