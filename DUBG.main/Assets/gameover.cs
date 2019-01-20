using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class gameover : MonoBehaviour {
    Slider slider;
    public GameObject Gameover1;
    public GameObject Gameover2;
    public GameObject Gameover3;
    public GameObject Gameover4;
    public GameObject Gameover5;
    public float deathdamage = 100f;
    
    // Use this for initialization
    void Start () {
        slider = GameObject.Find("Slider").GetComponent<Slider>();
        
    }
	
	// Update is called once per frame
	void Update () {
        if (slider.value >= deathdamage)
        {
            Gameover1.SendMessage("Lose1");
            Gameover2.SendMessage("Lose2");
            Gameover3.SendMessage("Lose3");
            Gameover4.SendMessage("Lose4");
            Gameover5.SendMessage("Lose5");
            
        }
    }
}
