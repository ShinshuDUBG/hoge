using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Highscore : MonoBehaviour {
    public point point;
    public int score;

	// Use this for initialization
	void Start () {
        score = point.Point;
        this.GetComponent<Text>().text = "Score:" + score.ToString();
    }
	
	// Update is called once per frame
	void Update () {

        

    }
}
