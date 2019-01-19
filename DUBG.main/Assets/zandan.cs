using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class zandan : MonoBehaviour {
    bool isRunning = false;
    public int shoutcount = 100;
    public GameObject bullet;
    Rigidbody rd;
    float TimeCount = 2; 




    // Use this for initialization
    void Start () {
        this.GetComponent<Text>().text = "×" + shoutcount;
      



    }

        // Update is called once per frame
        void Update()
    {
        

        if (Input.GetButton("reload") )
        {
            TimeCount -= Time.deltaTime;
            if (TimeCount <= 0)
            {
           
            shoutcount = 100;
            this.GetComponent<Text>().text = "×" + shoutcount;
                TimeCount = 2;
            }


          

        }

        if (Input.GetAxisRaw("Fire") == 1)
        {
            if (shoutcount < 1)

                return;
            shoutcount -= 1;
            this.GetComponent<Text>().text = "×" + shoutcount;
            


        }
            



    }
   
    

}
