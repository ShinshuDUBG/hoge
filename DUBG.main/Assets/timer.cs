using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timer : MonoBehaviour {
    float time;
    Text text;
    Slider slider;
    public int minute;
    public int second;

    void Start()
    {
        time = 0;
        text = GetComponent<Text>();
        slider = GameObject.Find("Slider").GetComponent<Slider>();
    }

    void Update()
    {
        if (slider.value >= 100)
            return;
        time += Time.deltaTime;
        minute = (int)time / 60;
        second = (int)time % 60;
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
