using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour {
    public GameObject bullet;
    Rigidbody rd;
    public float verticalAim;
    public bool groundIs;
    public bool waterIs;
    public Gun gun1;
    public Gun gun2;
    public GameObject[] guns;
    public int bulletNum;
    public int intervalCnt;
    public int[] interval = { 0, 30, 60 };
    public int HP;
    public bool isGunGetable;
    public GameObject gettableGun;
	// Use this for initialization
	void Start () {
        rd = GetComponent<Rigidbody>();
        groundIs = false;
        verticalAim = 0f;
        bulletNum = 30;
        HP = 10;
        isGunGetable = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (groundIs)
        {
            if (rd.velocity.magnitude <= 10f)//速度10以上
            {
                rd.AddForce(transform.forward * 2000f * -Input.GetAxisRaw("Mouse Y"));
                rd.AddForce(transform.right * 2000f * Input.GetAxisRaw("Mouse X"));
                rd.AddForce(transform.up * 100f);
            }
            if (Input.GetButtonDown("Jump"))
            {
                rd.AddForce(0f, 12000f, 0f);
            }
        }
        transform.Rotate(0f, Input.GetAxisRaw("Horizontal") * 90f * Time.deltaTime, 0f);
        transform.GetChild(0).transform.Rotate(-Input.GetAxisRaw("Vertical") * 90 * Time.deltaTime, 0f, 0f);


        if (Input.GetAxisRaw("Fire") == 1 && intervalCnt > 30)
        {
            Instantiate(bullet, this.transform.position + this.transform.forward * 1f+ this.transform.up * 0.4f, this.transform.GetChild(0).transform.rotation);
            intervalCnt = 0;
        }
        intervalCnt++;

        if (isGunGetable && Input.GetButtonDown("Pick"))
        {
            if (gun2 == null) {
               gun2 = gettableGun.GetComponent<Gun>();
            }
            else
            {
                gun1 = gettableGun.GetComponent<Gun>();
                switch (gun1.tag)
                {
                    case "gun1":
                        Instantiate(guns[0], this.transform.position + transform.up * 2f + transform.forward * 2f, Quaternion.identity);
                        break;
                    case "gun2":
                        Instantiate(guns[1], this.transform.position + transform.up * 2f + transform.forward * 2f, Quaternion.identity);
                        break;
                    case "gun3":
                        Instantiate(guns[2], this.transform.position + transform.up * 2f + transform.forward * 2f, Quaternion.identity);
                        break;
                }
            }
             GetComponent<Gun>();
            Destroy(gettableGun);
        }
        if (Input.GetButtonDown("Translate"))
        {
            Gun tmp = gun1;
            gun1 = gun2;
            gun2 = tmp;
        }
    }

    void OnCollisionStay(Collision col)
    {
        if (col.gameObject.tag == "Ground" && !waterIs)
        {
            groundIs = true;
        } else if (col.gameObject.tag == "enemysBullet")
        {
            Destroy(col.gameObject);
            HP--;
        }
        else if(col.gameObject.tag == "gun1" || col.gameObject.tag == "gun2" || col.gameObject.tag == "gun3")
        {
            isGunGetable = true;
            gettableGun = col.gameObject;
        }
    }
    private void OnCollisionExit(Collision col)
    {
        if (col.gameObject.tag == "Ground")
        {
            groundIs = false;
        } else if(col.gameObject.tag == "Gun")
        {
            isGunGetable = false;
        }
    }
}
