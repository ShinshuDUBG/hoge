using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class syuuryou : MonoBehaviour
{

    void Start()
    {
        this.gameObject.GetComponent<Text>().enabled = false;
    }

    public void Lose2()
    {

        this.gameObject.GetComponent<Text>().enabled = true;

    }
 
}
