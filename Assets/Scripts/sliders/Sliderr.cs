using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sliderr : MonoBehaviour
{   
    public static Sliderr instance;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }
}
