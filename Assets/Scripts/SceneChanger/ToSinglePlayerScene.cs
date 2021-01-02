using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToSinglePlayerScene : MonoBehaviour
{
   public void StartSingle()
    {
        SceneManager.LoadScene("SinglePlayerScene");
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
