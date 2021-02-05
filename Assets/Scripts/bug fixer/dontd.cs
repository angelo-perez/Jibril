using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dontd : MonoBehaviour
{

    public static dontd instance;

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
