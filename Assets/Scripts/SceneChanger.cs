﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneChanger : MonoBehaviour
{
   public void StartSingle()
    {
        SceneManager.LoadScene("SinglePlayerScene");
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("Menu");
    }
    public void StartMulti()
    {
        SceneManager.LoadScene("MultiplayerScene");
    }
    public void QuitButton()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}