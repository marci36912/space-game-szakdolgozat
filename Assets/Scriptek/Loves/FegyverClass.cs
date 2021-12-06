using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FegyverClass
{
    private string nev;
    private int tar;
    private int sebzes;
    private int bulletCount;
    private float cooldown;
    private float spread;
    private float bulletVelocity;


    public FegyverClass()
    {

    }
    public FegyverClass(string nev, float cd, int tar, float spr, int sebzes, float bvc, int bc)
    {
        this.nev = nev;
        this.cooldown = cd;
        this.tar = tar;
        this.spread = spr;
        this.sebzes = sebzes;
        this.bulletVelocity = bvc;
        this.bulletCount = bc;
    }

    #region getek
    public string GetNev()
    {
        return nev;
    }

    public int GetTar()
    {
        return tar;
    }

    public int GetSebzes()
    {
        return sebzes;
    }

    public float GetCooldown()
    {
        return cooldown;
    }

    public float GetSpread()
    {
        return spread;
    }

    public float GetBuVell()
    {
        return bulletVelocity;
    }

    public int GetCount()
    {
        return bulletCount;
    }
    #endregion
}
