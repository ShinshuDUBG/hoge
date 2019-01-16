using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timer : MonoBehaviour {
    float time;
    Text text;

    void Start()
    {
        time = 0;
        text = GetComponent<Text>();
    }

    void Update()
    {
        time += Time.deltaTime;
        int minute = (int)time / 60;
        int second = (int)time % 60;
        string minText, secText;
        if (minute < 10)
            minText = "0" + minute.ToString();
        else
            minText = minute.ToString();
        if (second < 10)
            secText = "0" + second.ToString();
        else
            secText = second.ToString();

        text.text = minText + ":" + secText;
    }
}
