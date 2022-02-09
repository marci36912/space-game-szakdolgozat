using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public float cd;
    public int ammo;

    [SerializeField] private KeyCode shooting;
    [SerializeField] private Transform sp;
    [SerializeField] private LineRenderer lr;


    private void Start()
    {
        ammo = 4;
    }
    private void Update()
    {
        if (ammo == 0)
        {
            reload();
        }
        if (Input.GetKeyDown(shooting) && cd < Time.time && ammo > 0)
        {
            StartCoroutine(shoot());
        }
    }

    private void reload()
    {
        ammo = 4;
        cd = Time.time + 1.5f;
    }

    private IEnumerator shoot()
    {
        int mask = LayerMask.GetMask("Player", "Fold");
        RaycastHit2D rc = Physics2D.Raycast(sp.position, sp.right, Mathf.Infinity, mask);
        if (rc)
        {
            Health player = rc.transform.GetComponentInChildren<Health>();
            
            if (player != null)
            {
                player.getHit();
            }

            lr.SetPosition(0, sp.position);
            lr.SetPosition(1, rc.point);
        }
        else
        {
            lr.SetPosition(0, sp.position);
            lr.SetPosition(1, sp.position + sp.right * 100);
        }

        lr.enabled = true;
        cd = Time.time + 1f;
        yield return new WaitForSeconds(0.02f);
        lr.enabled = false;
        ammo--;
    }
}
