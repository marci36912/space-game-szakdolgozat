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
    [SerializeField] private GameObject reloadText;
    [SerializeField] private ParticleSystem shotgunFlash;

    private GunsNEW details;
    private bool shot;
    private bool keyUp = true;
    private float timeCharge;


    private void Start()
    {
        details = new GunsNEW();
        ammo = details.GetTar();
        timeCharge = 0;
    }
    private void Update()
    {
        if (!details.getCharge())
        {      
            if (Input.GetKeyDown(shooting) && cd < Time.time && ammo > 0)
            {
                shot = true;
            }
        }
        else
        {
            if (keyUp && Input.GetKey(shooting) && cd < Time.time && ammo > 0)
            {
                if (!(timeCharge > details.GetCooldown()))
                {
                    lr.enabled = true;
                    lr.startWidth = 0.03f;
                    lr.SetPosition(0, sp.position);
                    lr.SetPosition(1, sp.position + sp.right * 100);
                    timeCharge += Time.fixedDeltaTime;
                }
                else
                {
                    keyUp = false;
                    shot = true;
                    return;
                }
            }
            if (Input.GetKeyUp(shooting))
            {
                keyUp = true;
                shot = true;
            }
        }
    }
    private void FixedUpdate()
    {
        if (ammo == 0)
        {
            reload();
        }
        if (shot)
        {
            gunCheck();
        }
    }
    private void reload()
    {
        Instantiate(reloadText, transform.position, Quaternion.identity, transform);
        ammo = details.GetTar();
        cd = Time.time + 1.5f;
    }
    private void gunCheck()
    {
        if (details.GetNev() == "Shotgun")
        {
            shootShotgun();
        }
        else if (details.GetNev() == "Charge Rifle")
        {
            StartCoroutine(shootCharge());
        }
        else if (details.GetNev() == "Burst Rifle")
        {
            StartCoroutine(shootBurst());
        }
        else
        {
            StartCoroutine(shoot());
        }
    }
    private IEnumerator shootBurst()
    {
        lr.startWidth = 0.07f;
        shot = false;
        int mask = LayerMask.GetMask("Player");
        for (int i = 0; i < details.GetCount(); i++)
        {
            lr.enabled = true;
            RaycastHit2D rc = Physics2D.Raycast(sp.position, sp.right, Mathf.Infinity, mask);
            if (rc)
            {
                var player = rc.transform.GetComponentInChildren<HealthNEW>();

                if (player != null)
                {
                    player.sebzes(details.GetSebzes());
                }

                lr.SetPosition(0, sp.position);
                lr.SetPosition(1, rc.point);
            }
            else
            {
                lr.SetPosition(0, sp.position);
                lr.SetPosition(1, sp.position + sp.right * 100);
            }
            
            yield return new WaitForSeconds(0.1f);
            lr.enabled = false;
            yield return new WaitForSeconds(0.1f);
        }
        cd = Time.time + details.GetCooldown();
        ammo--;
    }
    private IEnumerator shootCharge()
    {
        lr.enabled = false;
        shot = false;
        if (timeCharge > details.GetCooldown())
        {
            lr.startWidth = 0.09f;
            int mask = LayerMask.GetMask("Player");
            RaycastHit2D rc = Physics2D.Raycast(sp.position, sp.right, Mathf.Infinity, mask);
            if (rc)
            {
                var player = rc.transform.GetComponentInChildren<HealthNEW>();

                if (player != null)
                {
                    player.sebzes(details.GetSebzes());
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
            cd = Time.time + details.GetCooldown();
            yield return new WaitForSeconds(0.04f);
            lr.enabled = false;
            ammo--;
        }    
        timeCharge = 0;
    }
    private void shootShotgun()
    {
        shot = false;
        int mask = LayerMask.GetMask("Player");
        for (int i = 0; i < details.GetCount(); i++)
        {          
            float tmp = UnityEngine.Random.Range(-details.GetSpread(), details.GetSpread());
            //Debug.DrawRay(sp.transform.position, sp.right + new Vector3(0, tmp, 0), Color.green);
            RaycastHit2D rc = Physics2D.Raycast(sp.position, sp.right + new Vector3(0, tmp, 0), Mathf.Infinity, mask);
            if (rc)
            {
                var player = rc.transform.GetComponentInChildren<HealthNEW>();

                if (player != null)
                {
                    player.sebzes(details.GetSebzes());
                }
            }
        }
        Instantiate(shotgunFlash, sp.position, Quaternion.LookRotation(sp.right));
        cd = Time.time + details.GetCooldown();
        ammo--;
    }
    private IEnumerator shoot()
    {
        lr.startWidth = 0.09f;
        shot = false;
        int mask = LayerMask.GetMask("Player");
        RaycastHit2D rc = Physics2D.Raycast(sp.position, sp.right, Mathf.Infinity, mask);
        if (rc)
        {
            var player = rc.transform.GetComponentInChildren<HealthNEW>();
            
            if (player != null)
            {
                player.sebzes(details.GetSebzes());
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
        cd = Time.time + details.GetCooldown();
        yield return new WaitForSeconds(0.02f);
        lr.enabled = false;
        ammo--;
    }
    
    public void getDetails(GunsNEW g)
    {
        details = g;
        reload();
    }
}
