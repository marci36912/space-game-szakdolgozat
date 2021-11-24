using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kovetes : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float sebesseg = 0.5f;
    private Animator anim;
    private float tavolsag = 0.8f;
    private float tav;
    private bool flipp = false;
    private Utes utes;


    private void Start()
    {
        anim = GetComponent<Animator>();

        utes = GetComponent<Utes>();
    }
    void Update()
    {
        tav = transform.position.x - player.position.x;

        if (Mathf.Abs(tav) > tavolsag)
        {
            anim.SetFloat("sebesseg", 1);
        }
        else
        {
            //utes.megut();
            anim.SetFloat("sebesseg", 0);
        }

        if (Vector2.Distance(transform.position, player.position) > tavolsag)
        {
            
            transform.position = Vector2.MoveTowards(transform.position, player.position, sebesseg * Time.deltaTime);
        }
        else
        {
            //Debug.Log("xd");
        }

        if (flipp == false && tav > 0)
        {
            flip();
        }
        else if (flipp == true && tav < 0)
        {
            flip();
        }
    }

    private void flip()
    {
        flipp = !flipp;

            transform.Rotate(0, 180f, 0);       
    }
}
