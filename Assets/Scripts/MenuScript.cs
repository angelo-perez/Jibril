using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using TMPro;




public class MenuScript : MonoBehaviour
{
    public AudioMixer audioMixer;
    public AudioMixer sfx;
    public float number;
    public float number2;
    public float number3;
    public float number4;
    public int number5;



    void Start()
    {
        number4 = PlayerPrefs.GetFloat("volume2");
        number3 = PlayerPrefs.GetFloat("volume1");
        audioMixer.SetFloat("volume", number3);
        sfx.SetFloat("vol", number4);
    }






    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
        number3 = volume;
        PlayerPrefs.SetFloat("volume1", number3);
    }
    public void Setsfx(float volume)
    {
        sfx.SetFloat("vol", volume);
        number4 = volume;
        PlayerPrefs.SetFloat("volume2", number4);
    }
    public void timer1(int val)
    {
        if (val == 0)
        {
            PlayerPrefs.SetFloat("time1", 60f);
            number = PlayerPrefs.GetFloat("time1");
        }

        if (val == 1)
        {
            PlayerPrefs.SetFloat("time1", 180f);
            number = PlayerPrefs.GetFloat("time1");
        }
        if (val == 2)
        {
            PlayerPrefs.SetFloat("time1", 300f);
            number = PlayerPrefs.GetFloat("time1");
        }
    }
    public void timer2(int val)
    {
        if (val == 0)
        {
            PlayerPrefs.SetFloat("time2", 5f);
            number2 = PlayerPrefs.GetFloat("time2");
        }
        if (val == 1)
        {
            PlayerPrefs.SetFloat("time2", 10f);
            number2 = PlayerPrefs.GetFloat("time2");
        }
        if (val == 2)
        {
            PlayerPrefs.SetFloat("time2", 15f);
            number2 = PlayerPrefs.GetFloat("time2");
        }
        if (val == 3)
        {
            PlayerPrefs.SetFloat("time2", 20f);
            number2 = PlayerPrefs.GetFloat("time2");
        }

    }
    public void wordLength(int val)
    {
        if (val == 0)
        {
            PlayerPrefs.SetInt("wordL", 4);
            number5 = PlayerPrefs.GetInt("wordL");
        }
        if (val == 1)
        {
            PlayerPrefs.SetInt("wordL", 5);
            number5 = PlayerPrefs.GetInt("wordL");
        }
        if (val == 2)
        {
            PlayerPrefs.SetInt("wordL", 6);
            number5 = PlayerPrefs.GetInt("wordL");
        }
        if (val == 3)
        {
            PlayerPrefs.SetInt("wordL", 100);
            number5 = PlayerPrefs.GetInt("wordL");
        }

    }


}