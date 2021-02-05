using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttencheck : MonoBehaviour
{
    void Start()
    {
        PlayerPrefs.SetInt("checkthat",1);
    }
    public void onClick()
    {
        PlayerPrefs.SetInt("checkthat",0);
    }

}
