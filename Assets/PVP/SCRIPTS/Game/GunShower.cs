using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GunShower : MonoBehaviour
{
    [SerializeField] private Transform[] spawnok;
    [SerializeField] private GameObject[] fegyverek;

    private List<float> Chances = new List<float>();
    private float rnd;
    private float cd;

    private void Start()
    {
        for (int i = 0; i < GunsCollection.getCount(); i++)
        {
            Chances.Add(GunsCollection.returnGun(i).getChance());
        }

        Chances = Chances.OrderBy(x => x).ToList();
    }
    private void LateUpdate()
    {
        if (cd <= Time.time)
        {
            spawnGun();
        }
    }

    private void spawnGun()
    {
        Instantiate(fegyverek[getGunID()], new Vector3(getRandom(), 10), Quaternion.identity);
        cd = Time.time + 20;
    }
    private int getGunID()
    {
        rnd = Random.RandomRange(0f, 1f);

        Debug.Log(rnd);

        for (int i = 0; i < Chances.Count - 1; i++)
        {
            if (Chances[i] >= rnd)
            {
                return i;
            }
        }
        return 0;
    }

    private int getID()
    {
        return Random.Range(0, fegyverek.Length);
    }
    private float getRandom()
    {
        return Random.Range(spawnok[0].position.x, spawnok[1].position.x);
    }
}

public enum FegyverekID
{
    Revolver,
    AssaultRifle,
    BurstRifle,
    ChargeRifle,
    Shotgun,
    Sniper
}