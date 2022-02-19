using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunShower : MonoBehaviour
{
    [SerializeField] private Transform[] spawnok;
    [SerializeField] private GameObject[] fegyverek;

    private void LateUpdate()
    {
        
    }
    private float getRandom()
    {
        return Random.Range(spawnok[0].position.x, spawnok[1].position.x);
    }
}
