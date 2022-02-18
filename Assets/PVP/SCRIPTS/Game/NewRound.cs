using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewRound : MonoBehaviour
{
    [SerializeField] private Transform[] spawnsP1;
    [SerializeField] private Transform[] spawnsP2;

    private GameObject p1;
    private GameObject p2;

    private void Start()
    {
        p1 = GameObject.Find("P1");
        p2 = GameObject.Find("P2");

        p1.transform.position = spawnsP1[Random.Range(0, spawnsP1.Length)].position;
        p2.transform.position = spawnsP2[Random.Range(0, spawnsP2.Length)].position;
    }
}
