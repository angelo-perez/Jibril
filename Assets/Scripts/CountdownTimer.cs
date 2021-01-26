using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CountdownTimer : MonoBehaviour
{
    [SerializeField] float timer = 10f;
    [SerializeField] TextMeshProUGUI timerText;
    float time = 0f;
    void Start()
    {
        StartCoroutine(CountdownBegins());
    }

    private IEnumerator CountdownBegins()
    {
        time = timer;
        do
        {
            time -= Time.deltaTime;
            FormatText();
            yield return null;
        } while (time > 0);
    }
    private void FormatText()
    {
        int minutes = (int)(time/60) % 60;
        float seconds = (time % 60); 
        string secString = seconds.ToString("F2");
        timerText.text = "";
        timerText.text = minutes +":" + secString;
    }
}
