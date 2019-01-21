using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BuckTitle : MonoBehaviour {
    bool gameoverflg = false;
	// Use this for initialization
	void Start () {
        this.gameObject.GetComponent<Text>().enabled = false;

    }
	
	// Update is called once per frame
	void Update () {
        if (gameoverflg == true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Application.LoadLevel("Title");
            }
        }
        
		
	}

    public void Lose6()
    {
        this.gameObject.GetComponent<Text>().enabled = true;
        gameoverflg = true;

    }
}
