using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour {
    public int n;
    public int cooltime;
    public int bulletNum;
    public int shootcount;
    public void Create(int n, int cooltime, int bulletNum, int shootcount)
    {
        this.n = n;
        this.cooltime = cooltime;
        this.bulletNum = bulletNum;
        this.shootcount = shootcount;
    }
    void Update()
    {
        if(transform.position.y < 0)
        {
            Destroy(gameObject);
        }
    }
}
