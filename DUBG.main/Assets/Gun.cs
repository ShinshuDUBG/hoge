using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour {
    public int n;
    public int cooltime;
    public int bulletNum;
    public void Create(int n, int cooltime, int bulletNum)
    {
        this.n = n;
        this.cooltime = cooltime;
        this.bulletNum = bulletNum;
    }
}
