﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsss : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetFloat("time1", 60f);
        PlayerPrefs.SetFloat("time2", 5f);
    }


}
