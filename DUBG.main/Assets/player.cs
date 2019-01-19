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
    float hp = 0;

    public GameObject gunObj;
    public Gun gunScr; 

    private int[] n = new int[2];//装備1、装備2の番号(-1から3)
    private int[] power = new int[2];
    private float[] strength = new float[2];
    private int[] bulletNum = new int[2];
    private int[] cooltime = new int[2];

    public bool gunGettable = false;
    private Gun gettableGunScr;
    private GameObject gettableGunObj;
    public GameObject[] GunObj;
    public GameObject[] bullets;

    // Use this for initialization
    void Start () {
        rd = GetComponent<Rigidbody>();
        slider = GameObject.Find("Slider").GetComponent<Slider>();
        groundIs = false;
        verticalAim = 0f;

        gunScr = GunObj[0].GetComponent<Gun>();
        setGun(0, gunScr);
        n[1] = -1;
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
                Instantiate(bullet, this.transform.position + this.transform.forward * 5f + this.transform.up * 0.4f, this.transform.GetChild(0).transform.rotation);
            }
        }
        if (Input.GetButton("reload"))
        {
            
                TimeCount -= Time.deltaTime;
                if (TimeCount <= 0)
                {

                    shoutcount = bulletNum[0];

                    TimeCount = 2;
                }
            
        }

        if( gunGettable && Input.GetButton("Pick") )
        {
            Debug.Log("AAAAA");
            if( n[1] == -1)
            {
                setGun(1, gettableGunScr);
                Destroy(gettableGunObj);
            }
            else
            {
                GameObject s = Instantiate(GunObj[n[0]], gameObject.transform.position + gameObject.transform.forward * 2f + gameObject.transform.up * 2f, Quaternion.identity) as GameObject;
                Gun g = s.GetComponent<Gun>();
                g.Create( n[0], cooltime[0], bulletNum[0], power[0], strength[0], bullets[ n[0] ] );
                setGun(0, gettableGunScr);
                Destroy(gettableGunObj);
                shoutcount = bulletNum[0];
            }
            gunGettable = false;
        }

        if( Input.GetButton("Change"))
        {
            exchangeGun();
        }

    }

    void OnCollisionStay(Collision col)
    {
        if(col.gameObject.tag == "Ground")
        {
            groundIs = true;
        }
        else if( col.gameObject.tag == "gun0" || col.gameObject.tag == "gun1" || col.gameObject.tag == "gun2" || col.gameObject.tag == "gun3")
        {
            gunGettable = true;
            gettableGunObj = col.gameObject;
            gettableGunScr = col.gameObject.GetComponent<Gun>();
        }
    }
    private void OnCollisionEnter(Collision col)
    {
        if (col.transform.tag == "bullet")
        {
            hp += 1;
            slider.value = hp;
        }
    }

    private void OnCollisionExit(Collision col)
    {
        if(col.gameObject.tag == "gun0" || col.gameObject.tag == "gun1" || col.gameObject.tag == "gun2" || col.gameObject.tag == "gun3")
        {
            gunGettable = false;
        }
    }

    private void setGun(int i , Gun g)
    {
        n[i] = g.n;
        power[i] = g.power;
        strength[i] = g.strength;
        bulletNum[i] = g.bulletNum;
        cooltime[i] = g.cooltime;
    }

    private void exchangeGun()
    {
        int tmpN = n[1];
        int tmpP = power[1];
        float tmpS = strength[1];
        int tmpB = bulletNum[1];
        int tmpC = cooltime[1];

        n[1] = n[0];
        power[1] = power[0];
        strength[1] = strength[0];
        bulletNum[1] = bulletNum[0];
        cooltime[1] = cooltime[0];

        n[0] = tmpN;
        power[0] = tmpP;
        strength[0] = tmpS;
        bulletNum[0] = tmpB;
        cooltime[0] = tmpC;
    }
}
