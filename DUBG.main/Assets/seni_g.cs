using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class seni_g : MonoBehaviour {
    public GameObject Result1;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
       
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Result1.SendMessage("result1");
           


        }
        
    }
   
}
