using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menuToGame : MonoBehaviour
{


    public GameObject canvas;
    public int checkthis;
    public int checker;

    

    void Update()
    {
        checker = PlayerPrefs.GetInt("checkthat");
        if (checker == 0)
        { 
            canvas.SetActive(true);
        }
        else
        {
            canvas.SetActive(false);
        }
    }


}
