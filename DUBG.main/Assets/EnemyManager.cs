using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour {
    public GameObject Enemy;
    public float spaunTime = 0.1f;
    float count = 0;
	// Use this for initialization
	void Start () {
        for (int i = 0; i < 300; i++)
        {
               Instantiate(Enemy, new Vector3(Random.Range(-78f, 1236f), 300f, Random.Range(-1239f, -2313f)), Quaternion.identity);
        }
    }
	
	// Update is called once per frame
	void Update () {
            
	}
}
