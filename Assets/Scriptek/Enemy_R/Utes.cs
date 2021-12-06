using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utes : MonoBehaviour
{
    [SerializeField] private Transform playerCheck;
    [SerializeField] private LayerMask player;
    [SerializeField] private float lokes = 100;
    [SerializeField] private float dmg = 1;
    [SerializeField] private ParticleSystem hitEff;
    private Animator anim;
    private bool zonaban;
    private float atmero = 0.8f;
    private float ido = 0;
    private float cd = 10;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        zonaban = Physics2D.OverlapCircle(playerCheck.position, atmero, player);

        if (zonaban)
        {
            anim.SetBool("utE", true);
            megut();                       
        }
        else
        {
            anim.SetBool("utE", false);
        }        
    }

    public void megut()
    {
        if (ido <= Time.time)
        {
            Instantiate(hitEff, playerCheck.position, Quaternion.identity);
            PlayerHP.Instance.sebzes(dmg, lokes);
            ido = Time.time + cd;
        }                                  
    }
}
