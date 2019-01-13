using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour {
    public GameObject Enemy;
    public float spaunTime = 2.0f;
    float count = 0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        count += Time.deltaTime;
        if(count >= spaunTime)
        {
            count = 0f;
            Instantiate(Enemy, new Vector3(50f + Random.Range(-100f,100f), 100f, -1852f + Random.Range(-100f, 100f)), Quaternion.identity);
        }
	}
}
