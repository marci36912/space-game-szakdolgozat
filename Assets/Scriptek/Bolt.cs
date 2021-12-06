using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Bolt : MonoBehaviour
{
    [SerializeField] private TextMeshPro e;
    [SerializeField] private Canvas BoltUI;
    [SerializeField] private Animator boltSz;

    private Animator anim;
    private bool bolt;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        boltSz.SetBool("nyitva", bolt);
        anim.SetBool("nyitvaE", bolt);
        if (Input.GetKeyDown(KeyCode.E) && bolt)
        {                                 
            BoltUI.enabled = true;  //ID’ MEG¡LLÌT¡SA MIK÷ZBEN V¡S¡RL¡S VAN, MAJD FOLYTAT¡S, WAVE RENDSZER, KURVA ANY¡D
            Time.timeScale = 0;             
        }       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name.Equals("Player"))
        {     
            bolt = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name.Equals("Player"))
        {
        bolt = false;
        }
    }
}
