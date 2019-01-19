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
            for (int i = 0; i < 50; i++)
            {
                switch (Random.Range(0, 2))
                {
                    case 0:
                        Instantiate(Enemy, new Vector3(Random.Range(1258f, 1408f), 300f, Random.Range(-1503f, -1809f)), Quaternion.identity);
                        break;
                    case 1:
                        Instantiate(Enemy, new Vector3(Random.Range(500f, 700f), 300f, Random.Range(-1486f, -1703f)), Quaternion.identity);
                        break;
                }
            }
        }
	}
}
