using UnityEngine;

public class GunsNEW : FegyverClass
{
    private float chance;
    private bool charge;
    public GunsNEW(string nev, float cd, int tar, float spr, int sebzes, int bc, float chance, bool charge)
    {
        this.nev = nev;
        this.cooldown = cd;
        this.tar = tar;
        this.spread = spr;
        this.sebzes = sebzes;
        //this.bulletVelocity = bvc;
        this.bulletCount = bc;
        this.chance = chance;
        this.charge = charge;
    }
    public GunsNEW()
    {
        this.nev = "Default Pistol";
        this.cooldown = 1;
        this.tar = 4;
        this.spread = 0;
        this.sebzes = 10;
        this.bulletCount = 1;
    }

    public bool getCharge()
    {
        return charge;
    }
}
