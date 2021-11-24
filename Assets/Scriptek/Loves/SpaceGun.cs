using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceGun : MonoBehaviour
{
    public static SpaceGun Instance;

    [SerializeField] private Transform sp;
    [SerializeField] private GameObject bullet;
    [SerializeField] private SpriteRenderer mf;
    [SerializeField] private SpriteRenderer gun;
    [SerializeField] private Sprite ar;
    [SerializeField] private Sprite sg;


    private int aktiv = 2;
    private int tar;
    private float cd = 0;

    private static FegyverClass aktivFegyver; //0=pt,1=ar,2=sg

    private float velocity, spread;

    private void Start()
    {
        Instance = this;

        ActiveFegyver();

        tar = aktivFegyver.GetTar();

        velocity = aktivFegyver.GetBuVell();
        spread = aktivFegyver.GetSpread();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (tar > 0)
            {
                if (cd < Time.time)
                {
                    StartCoroutine(loves());
                    cd = aktivFegyver.GetCooldown() + Time.time;
                }
            }
            else
            {
                tar = aktivFegyver.GetTar();
                cd = Time.time + 1.5f;
            }
        }
    }

    #region metodusok
    private void ActiveFegyver()
    {
        switch (aktiv)
        {
            case 0:
                aktivFegyver = Fegyverek.GetFegyver(0);
                break;
            case 1:
                aktivFegyver = Fegyverek.GetFegyver(1);
                gun.sprite = ar;
                gun.transform.Rotate(0, 0, -90);
                sp.Rotate(0, 0, 90);
                sp.localPosition = new Vector3(0.655f, 0.034f, sp.position.z);
                break;
            case 2:
                aktivFegyver = Fegyverek.GetFegyver(2);
                gun.sprite = sg;
                gun.transform.Rotate(0, 0, -90);
                sp.Rotate(0, 0, 90);
                sp.localPosition = new Vector3(0.481f, -0.017f, sp.transform.position.z);
                break;
            default:
                aktivFegyver = Fegyverek.GetFegyver(0);
                break;
        }
    }

    private IEnumerator loves()
    {
        mf.enabled = true;
        for (int i = 0; i < aktivFegyver.GetCount(); i++)
        {
            Instantiate(bullet, sp.position, Quaternion.identity);
            tar--;
        }
        yield return new WaitForSeconds(0.1f);
        mf.enabled = false;
    }
    #endregion

    #region returnok

    public float vellocity()
    {
        return velocity;
    }

    public float spreadd()
    {
        return spread;
    }

    public int maxTar()
    {
        return aktivFegyver.GetTar();
    }

    public int Tar()
    {
        return tar;
    }

    public int Damage()
    {
        return aktivFegyver.GetSebzes();
    }
    #endregion
}