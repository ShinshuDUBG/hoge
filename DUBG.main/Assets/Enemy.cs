using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int HP = 10;
    public int interval = 100;
    public bool isGround = false;
    private Rigidbody rig;
    public int n = 0;
    public GameObject bullet;
    private RaycastHit hit;
    private GameObject player;
    // Use this for initialization
    void Start()
    {
        HP = 10;
        rig = GetComponent<Rigidbody>();
        n = 0;
        isGround = false;
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (isGround)
        {
            n += 1;
            if (n > interval)
            {
                n = 0;
                transform.Rotate(0f, Random.Range(-180, 180), 0f);
            }
            rig.AddForce(transform.forward * 950f + transform.up * 950f);
        }
        Vector3 v1 = transform.rotation.ToEuler();
        Vector3 v = (player.transform.position - transform.position);
        if ( Vector3.Dot( (player.transform.position - transform.position).normalized, transform.rotation.ToEuler().normalized ) > 0f && Vector3.Distance(player.transform.position, transform.position) < 100f)
        {
            transform.LookAt(player.transform.position);
            Ray ray = new Ray(transform.position, player.transform.position);
            Debug.DrawLine(ray.origin, ray.direction * Mathf.Infinity, Color.red);
            Debug.Log("saaa");
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity))
            {
                if (hit.collider.tag == "Player")
                {
                    Debug.Log("aaaa");
                    Instantiate(bullet, this.transform.position + this.transform.forward * 1f + this.transform.up * 0.4f, transform.GetChild(0).transform.rotation);
                }
            }
        }
        if (HP <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.transform.tag == "bullet")
        {
            HP -= 1;
        }
    }

    private void OnCollisionStay(Collision col)
    {
        if (col.transform.tag == "Ground")
        {
            isGround = true;
        }
    }

    private void OnCollisionExit(Collision col)
    {
        if (col.transform.tag == "Ground")
        {
            isGround = false;
        }
    }
}
