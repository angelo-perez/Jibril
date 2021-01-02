using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToMultiplayerScene : MonoBehaviour
{
    public void StartMulti()
    {
        SceneManager.LoadScene("MultiplayerScene");
    }
}
