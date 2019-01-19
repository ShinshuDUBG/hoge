using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ranking : MonoBehaviour {

	// Use this for initialization
	void Start () {
        this.gameObject.GetComponent<Image>().enabled = false;
    }
	
	// Update is called once per frame
	public void result1 () {
        this.gameObject.GetComponent<Image>().enabled = true;
    }
}
