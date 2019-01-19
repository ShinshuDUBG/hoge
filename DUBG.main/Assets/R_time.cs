using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class R_time : MonoBehaviour {
    Text txt;
    Text targetText;


    void Start () {

        this.gameObject.GetComponent<Text>().enabled = false;
    }

    // Update is called once per frame
    public void Lose3()
    {
        
        this.gameObject.GetComponent<Text>().enabled = true;
        txt = GameObject.Find("timer").GetComponent<Text>();
        this.targetText = this.GetComponent<Text>();

        this.targetText.text = "生存時間　"　+　txt.text;
    }
}
