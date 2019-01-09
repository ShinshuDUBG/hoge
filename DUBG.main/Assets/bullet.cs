using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    Rigidbody rd;
    // Use this for initialization
    void Start()
    {
        rd = GetComponent<Rigidbody>();
        rd.AddForce(transform.forward * 1000f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision col)
    {
        if (col.transform.tag == "Ground")
        {
            Destroy(gameObject);
        }
    }
}
