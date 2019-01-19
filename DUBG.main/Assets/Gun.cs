using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour {
    public int n;
    public int cooltime;
    public int bulletNum;
    public int power;
    public float strength;
    public GameObject bullet;
    public void Create(int n, int cooltime, int bulletNum, int power, float strength, GameObject bullet)
    {
        this.n = n;
        this.cooltime = cooltime;
        this.bulletNum = bulletNum;
        this.power = power;
        this.strength = strength;
        this.bullet = bullet;
    }
}
