using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GunShower : MonoBehaviour
{
    [SerializeField] private Transform[] spawnok;
    [SerializeField] private GameObject[] fegyverek;

    private List<float> Chances;
    private float rnd;
    private float cd;

    private void Start()
    {
        RNJesus.seed(DateTime.Now.Millisecond);
        Chances = new List<float>();

        for (int i = 0; i < GunsCollection.getCount(); i++)
        {
            Chances.Add(GunsCollection.returnGun(i).getChance());
        }

        Chances = Chances.OrderBy(x => x).ToList();
    }
    private void FixedUpdate()
    {
        if (cd < Time.time)
        {
            spawnGun();
        }
    }

    private void spawnGun()
    {
        Instantiate(fegyverek[getGunID()], new Vector3(getRandom(), 10), Quaternion.identity);
        cd = Time.time + 5;
    }
    private int getGunID()
    {
        rnd = (float)RNJesus.even().rangeInclusive_f(0f, 1f);
        //Debug.Log(rnd);                 //szarul ellenorzi a szamokat es mindig ugyan azt a fegyvert adja vissza
        for (int i = 0; i < fegyverek.Length; i++)
        {
            if (Chances[i] > rnd)
            {
               // Debug.Log(Chances[i] + " : " + i + " : " + rnd);
                return i;
            }
        }
        return 0;
    }
    private float getRandom()
    {
        return UnityEngine.Random.Range(spawnok[0].position.x, spawnok[1].position.x);
    }
}