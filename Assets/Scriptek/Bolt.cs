using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Bolt : MonoBehaviour
{
    [SerializeField] private Canvas BoltUI;
    [SerializeField] private Animator boltSz;
    [SerializeField] private GameObject pauseMenu;

    private Animator anim;
    public static bool bolt;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        anim.SetBool("nyitvaE", ufo.wave);

        if (ufo.wave)
        {
            boltSz.SetBool("nyitva", bolt);
            if (Input.GetKeyDown(KeyCode.E) && bolt)
            {
                pauseMenu.SetActive(false);
                SpaceGun.Instance.cd = Time.time + 0.5f;
                BoltUI.enabled = true;
                Time.timeScale = 0;             
            }
        }
        else
        {
            boltSz.SetBool("nyitva", ufo.wave);         
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
