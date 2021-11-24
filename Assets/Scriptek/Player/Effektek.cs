using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effektek : MonoBehaviour
{
    [SerializeField] private ParticleSystem por;
    [SerializeField] private Transform fold;

    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.name == "platform")
        {          
                Instantiate(por, fold.position, Quaternion.identity);               
        }
    }
}
