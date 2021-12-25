using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceGun : MonoBehaviour
{
    public static SpaceGun Instance;

    [SerializeField] private Transform sp;
    [SerializeField] private GameObject bullet;
    [SerializeField] private GameObject reloadText;
    [SerializeField] private SpriteRenderer mf;
    [SerializeField] private GameObject mfFeny;
    [SerializeField] private SpriteRenderer gun;
    [SerializeField] private Sprite[] fegyverek;

    [HideInInspector] public float cd = 0;

    private int tar;

    public static FegyverClass aktivFegyver;

    private void Start()
    {
        Instance = this;

        ActiveFegyver(0);

        gun.transform.Rotate(0, 0, -90);
        sp.Rotate(0, 0, 90);
    }

    void Update()
    {
        if (tar == 0 || tar < aktivFegyver.GetTar() && Input.GetKeyDown(KeyCode.R) && cd < Time.time)
        {
            GameObject tmp = Instantiate(reloadText, new Vector3(sp.position.x, sp.position.y, 0), Quaternion.identity, gameObject.transform);
            Destroy(tmp, 1f);
            tar = aktivFegyver.GetTar();
            cd = Time.time + 1.5f;
        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {           
            if (cd < Time.time)
            {
                if (tar > 0)
                {
                    StartCoroutine(loves());
                    cd = aktivFegyver.GetCooldown() + Time.time;
                }
            }           
        }
    }

    #region metodusok
    public void ActiveFegyver(int aktiv)
    {
        switch (aktiv)
        {
            case 0:
                aktivFegyver = Fegyverek.GetFegyver(0);
                gun.sprite = fegyverek[0];              
                sp.localPosition = new Vector3(0.24f, -0.029f, sp.position.z);
                tar = aktivFegyver.GetTar();
                break;
            case 1:
                aktivFegyver = Fegyverek.GetFegyver(1);
                gun.sprite = fegyverek[1];
                sp.localPosition = new Vector3(0.655f, 0.034f, sp.position.z);
                tar = aktivFegyver.GetTar();
                break;
            case 2:
                aktivFegyver = Fegyverek.GetFegyver(2);
                gun.sprite = fegyverek[2];
                sp.localPosition = new Vector3(0.481f, -0.017f, sp.transform.position.z);
                tar = aktivFegyver.GetTar();
                break;            
        }
    }

    private IEnumerator loves()
    {
        mf.enabled = true;
        mfFeny.SetActive(true);
        for (int i = 0; i < aktivFegyver.GetCount(); i++)
        {
            Instantiate(bullet, sp.position, Quaternion.identity);
            tar--;
        }
        yield return new WaitForSeconds(0.1f);
        mf.enabled = false;
        mfFeny.SetActive(false);
    }
    #endregion

    public int Tar()
    {
        return tar;
    }
}