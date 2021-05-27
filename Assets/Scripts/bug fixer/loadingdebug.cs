using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class loadingdebug : MonoBehaviour
{

    public GameObject menu;

    public GameObject loading;

    public float valueLoading;
/*
    void Update()
    {
        if(menu.activeSelf && valueLoading == 1)
        {   
            loading.SetActive(false);
        }
    }
*/
    public void floatUpdate (float value)
    {
        valueLoading = value;
        if(value == 1)
        {   
            loading.SetActive(false);
            
        }
    }



}
