using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spaceship : MonoBehaviour
{
    [SerializeField] private Transform[] pontok;
    private Rigidbody2D spaceship;
    private Vector3 irany;
    private bool felfele;
    
    
    void Start()
    {
        Time.timeScale = 1;
        spaceship = GetComponent<Rigidbody2D>();
        felfele = true;
    }
    private void FixedUpdate()
    {
        if (felfele) 
        {
            mooveTo(0);
        }
        else if (!felfele)
        {
            mooveTo(1);
        }
    }

    private void mooveTo(int n)
    {
        irany = (pontok[n].position - transform.position).normalized;
        spaceship.AddForceAtPosition(irany, pontok[n].position);

        if (Vector3.Distance(transform.position, pontok[n].position) == 0)
        {
            felfele = !felfele;
        }
    }
}
