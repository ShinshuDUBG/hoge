using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    public int HP;
	// Use this for initialization
	void Start () {
        HP = 10;
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(0f,Random.Range(-180,180),0f);
        transform.Translate(0f,0f,10f*Time.deltaTime);
        if(HP <= 0)
        {
            Destroy(gameObject);
        }
	}

    private void OnCollisionEnter(Collision col)
    {
        if(col.transform.tag == "bullet")
        {
            HP -= 1;
        }
    }
}
