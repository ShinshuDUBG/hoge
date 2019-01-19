using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunSpawner : MonoBehaviour {
    public GameObject[] guns;

	// Use this for initialization
	void Start () {
		for(int i=0; i<100; i++)
        {
            for( int j=0; j<3; j++)
            {
                Instantiate(guns[j], new Vector3(Random.Range(-78f, 1236f), 120f, Random.Range(-1239f, -2313f)), Quaternion.Euler(0, 0, 0));
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
