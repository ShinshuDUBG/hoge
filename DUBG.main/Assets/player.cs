using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class player : MonoBehaviour {
    public GameObject bullet;
    Rigidbody rd;
    float TimeCount = 2;
    int shoutcount = 100;
    public float verticalAim;
    public bool groundIs;
    Slider slider;
    public float hp = 0;
    // Use this for initialization
    void Start () {
        rd = GetComponent<Rigidbody>();
        slider = GameObject.Find("Slider").GetComponent<Slider>();
        groundIs = false;
        verticalAim = 0f;
	}

    // Update is called once per frame
    void Update()
    {
        if (groundIs)
        {
            if (rd.velocity.magnitude <= 10f)
            {
                rd.AddForce(transform.forward * 950f * -Input.GetAxisRaw("Mouse Y"));
                rd.AddForce(transform.right * 950f * Input.GetAxisRaw("Mouse X"));
            }
            if (Input.GetButtonDown("Jump"))
            {
                groundIs = false;
                rd.AddForce(0f, 12000f, 0f);
            }
        }
        transform.Rotate(0f, Input.GetAxisRaw("Horizontal") * 90f * Time.deltaTime, 0f);
        transform.GetChild(0).transform.Rotate(-Input.GetAxisRaw("Vertical") * 90 * Time.deltaTime, 0f, 0f);
        if (Input.GetAxisRaw("Fire") == 1)
        {
            if (shoutcount > 0)
            {
                shoutcount -= 1;
                Instantiate(bullet, this.transform.position + this.transform.forward * 1f + this.transform.up * 0.4f, this.transform.GetChild(0).transform.rotation);
            }
        }
        if (Input.GetButton("reload"))
        {
            
                TimeCount -= Time.deltaTime;
                if (TimeCount <= 0)
                {

                    shoutcount = 100;

                    TimeCount = 2;
                }
            
        }
    }

    void OnCollisionStay(Collision col)
    {
        if(col.gameObject.tag == "Ground")
        {
            groundIs = true;
        }
    }
    private void OnCollisionEnter(Collision col)
    {
        if (col.transform.tag == "enemysBullet")
        {
            hp += 1;
            slider.value = hp;
        }
    }
}
