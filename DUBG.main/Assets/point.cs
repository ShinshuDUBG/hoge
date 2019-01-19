using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class point : MonoBehaviour
{
    Text txt;
    public timer time;
    public Enemy kill;
    public int time_p1, time_p2, time_p, kill_p,Point;
    



    
    void Start()
    {
        DontDestroyOnLoad(this);
        this.gameObject.GetComponent<Text>().enabled = false;
        
    }

    // Update is called once per frame
    public void Lose5()
    {
        
        this.gameObject.GetComponent<Text>().enabled = true;
        time_p1 = time.minute*60;
        time_p2 = time.second;
        time_p = time_p1 + time_p2;
        kill_p = kill.kill;
        Point = kill_p + time_p;
        this.GetComponent<Text>().text = "Score:"+ Point.ToString();
    }

   

}
