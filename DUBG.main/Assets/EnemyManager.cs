using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour {
    public GameObject Enemy;
    public float spaunTime = 0.1f;
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
            Instantiate(Enemy, new Vector3(Random.Range(-57f,1581f), 300f, Random.Range(-1132f, -2677f)), Quaternion.identity);
        }
	}
}
