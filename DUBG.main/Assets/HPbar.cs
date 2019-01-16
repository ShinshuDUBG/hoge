using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPbar : MonoBehaviour {


    Slider slider;
	// Use this for initialization
	void Start () {
        slider = GameObject.Find("Slider").GetComponent<Slider>();
		
	}

    // Update is called once per frame
    float hp = 0;
	void Update () {

        //hp += 1;
        //if (hp > slider.maxValue)
        //{
            //hp = slider.minValue;
        //}

        //slider.value = hp;
		
	}
    private void OnCollisionEnter(Collision col)
    {
        if (col.transform.tag == "bullet")
        {
            hp +=1;
            slider.value = hp;
        }
    }
}
