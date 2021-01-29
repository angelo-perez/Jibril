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
    public void SetVolume (float volume)
    {
        audioMixer.SetFloat("volume", volume);
    }
    public void Setsfx (float volume)
    {
        sfx.SetFloat("vol", volume);
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
    /*
    void Update()
    {
        PlayerPrefs.SetFloat("time1",number);
        PlayerPrefs.SetFloat("time2",number2);
    }
    */


}
