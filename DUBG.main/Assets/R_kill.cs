using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class R_kill : MonoBehaviour {
        Text txt;
        Text targetText;


        void Start()
        {

            this.gameObject.GetComponent<Text>().enabled = false;
        }

        // Update is called once per frame
        public void Lose4()
        {

            this.gameObject.GetComponent<Text>().enabled = true;
            txt = GameObject.Find("killnumber").GetComponent<Text>();
            this.targetText = this.GetComponent<Text>();

            this.targetText.text = txt.text;
        }
    
}
