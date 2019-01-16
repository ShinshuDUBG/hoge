using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Result : MonoBehaviour {

    void Start()
    {
        this.gameObject.GetComponent<Image>().enabled = false;
    }

    public void Lose1()
    {

        this.gameObject.GetComponent<Image>().enabled = true;

    }
}
