using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loves : MonoBehaviour
{
    [SerializeField] private Transform sp;
    [SerializeField] private LineRenderer lr;
    [SerializeField] private ParticleSystem hit;
    [SerializeField] private Rigidbody2D player;
    private Animator anim;
    private bool shooting = false;
    private int dmg = 1;
    private int irany;


    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        if (player.transform.rotation.y >= 0)
        {
            irany = 1;
        }
        else
        {
            irany = -1;
        }

        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            shooting = true;
        }
    }

    private void FixedUpdate()
    {
        anim.SetBool("Lovess", shooting);
        if (shooting)
        {            
            StartCoroutine(shoot());
        }        
    }

    private IEnumerator shoot()
    {
            RaycastHit2D rc = Physics2D.Raycast(sp.position, sp.right);
        shooting = false;
        if (rc)
            {
            Vector3 plyr = sp.position - rc.transform.position;
            HP enemy = rc.transform.GetComponent<HP>();

                Instantiate(hit, rc.point, Quaternion.LookRotation(plyr));

                lr.SetPosition(0, sp.position);
                lr.SetPosition(1, rc.point);

                 if (enemy != null)
                    {
                       enemy.getHit(dmg, irany);
                    }


            }
            else
            {
                lr.SetPosition(0, sp.position);
                lr.SetPosition(1, sp.position + sp.right * 100);
            }

        lr.enabled = true;
        yield return new WaitForSeconds(0.02f);
        lr.enabled = false;        
    }
}
