using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class player : MonoBehaviour {
    public GameObject bullet;
    Rigidbody rd;
    public float TimeCount = 2;
    public int shoutcount = 100;
    public float verticalAim;
    public bool groundIs;
    Slider slider;
    float hp = 0;

    public GameObject gunObj;
    public Gun gunScr; 

    private int[] n = new int[2];//装備1、装備2の番号(-1から3)
    private int[] bulletNum = new int[2];
    private int[] cooltime = new int[2];
    public int[] shootcount = new int[2];
    int interval = 0;
    bool gunBool = false;

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
        shootcount[0] = bulletNum[0];
        n[1] = -1;
	}

    // Update is called once per frame
    void Update()
    {
        interval += 1;
        if (groundIs)
        {
            if (rd.velocity.magnitude <= 10f)
            {
                rd.AddForce(transform.forward * 950f * -Input.GetAxisRaw("Mouse Y"));
                rd.AddForce(transform.right * 950f * Input.GetAxisRaw("Mouse X"));
                rd.AddForce(transform.up * 500f);
            }
            if (Input.GetButtonDown("Jump"))
            {
                groundIs = false;
                rd.AddForce(0f, 12000f, 0f);
            }
        }
        transform.Rotate(0f, Input.GetAxisRaw("Horizontal") * 90f * Time.deltaTime, 0f);
        transform.GetChild(0).transform.Rotate(-Input.GetAxisRaw("Vertical") * 90 * Time.deltaTime, 0f, 0f);
        if (n[0] == 0 || n[0] == 3)
        {
            if (Input.GetAxisRaw("Fire") == 1 && interval >= cooltime[0])
            {
                if (shootcount[0] > 0 && !gunBool)
                {
                    shootcount[0] -= 1;
                    Instantiate(bullets[n[0]], this.transform.position, this.transform.GetChild(0).transform.rotation);
                    interval = 0;
                    gunBool = true;
                }
            }else if(Input.GetAxisRaw("Fire") < 1)
            {
                gunBool = false;
            }
        }
        else {
            if (Input.GetAxisRaw("Fire") == 1 && interval >= cooltime[0])
            {
                if (shootcount[0] > 0)
                {
                    shootcount[0] -= 1;
                    Instantiate(bullets[n[0]], this.transform.position + this.transform.forward * 5f + this.transform.up * 0.4f, this.transform.GetChild(0).transform.rotation);
                    interval = 0;
                }
            }
        }
        if (Input.GetButton("reload"))
        {
                TimeCount -= Time.deltaTime;
                if (TimeCount <= 0)
                {

                    shootcount[0] = bulletNum[0];

                    TimeCount = 2;
                    move();
                }
        }
        else
        {
            TimeCount = 2;
        }

        if( gunGettable && Input.GetButtonDown("Pick") )
        {
            if( n[1] == -1)
            {
                setGun(1, gettableGunScr);
                shootcount[1] = bulletNum[1];
                Destroy(gettableGunObj);
            }
            else
            {
                GameObject s = Instantiate(GunObj[n[0]], gameObject.transform.position + gameObject.transform.forward * 2f + gameObject.transform.up * 2f, Quaternion.identity) as GameObject;
                Gun g = s.GetComponent<Gun>();
                g.Create( n[0], cooltime[0], bulletNum[0], shootcount[0]);
                setGun(0, gettableGunScr);
                Destroy(gettableGunObj);
                shoutcount = bulletNum[0];
            }
            move();
            gunGettable = false;
        }

        if( Input.GetButton("Change") && n[1] != -1 && groundIs)
        {
            exchangeGun();
            move();
        }

        var hits = Physics.SphereCastAll(
        transform.position,
        1f,
        transform.forward,
        1f,
        1 << 8
        ).Select(h => h.transform.gameObject).ToList();
        if( hits.Count() > 0)
        {
            gunGettable = true;
            gettableGunObj = hits[0].transform.gameObject;
            gettableGunScr = hits[0].transform.gameObject.GetComponent<Gun>();
        }
        else
        {
            gunGettable = false;
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
    private void OnCollisionExit(Collision col)
    {
        if(col.gameObject.tag == "Ground")
        {
            groundIs = false;
        }
    }

    private void setGun(int i , Gun g)
    {
        n[i] = g.n;
        bulletNum[i] = g.bulletNum;
        cooltime[i] = g.cooltime;
        shootcount[i] = g.shootcount;
    }

    private void exchangeGun()
    {
        int tmp1 = n[0];
        n[0] = n[1];
        n[1] = tmp1;

        int tmp2 = bulletNum[0];
        bulletNum[0] = bulletNum[1];
        bulletNum[1] = tmp2;

        int tmp3 = cooltime[0];
        cooltime[0] = cooltime[1];
        cooltime[1] = tmp3;

        int tmp4 = shootcount[0];
        shootcount[0] = shootcount[1];
        shootcount[1] = tmp4;
    }
    private void exchangeNum(int a, int b)
    {
        int tmp = a;
        a = b;
        b = tmp;
    }

    private void move()
    {
        this.transform.Translate(0f, 0.2f, 0f);
        groundIs = false;
    }
}
