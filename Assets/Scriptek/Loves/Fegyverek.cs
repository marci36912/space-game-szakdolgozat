using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fegyverek : MonoBehaviour
{
    public static readonly FegyverClass pisztoly = new FegyverClass("Pistol", 0.5f, 7, 0, 15, 50, 1);
    public static readonly FegyverClass assaultriffle = new FegyverClass("Assault Rifle", 0.3f, 15, 0, 25, 120, 1);
    public static readonly FegyverClass shotgun = new FegyverClass("Shotgun", 1, 24, 0.6f, 18, 35, 6);

    public static List<FegyverClass> fegyverek;
    private void Awake()
    {
        fegyverek = new List<FegyverClass>();

        fegyverek.Add(pisztoly);
        fegyverek.Add(assaultriffle);
        fegyverek.Add(shotgun);
    }

    public static FegyverClass GetFegyver(int s)
    {       
            return fegyverek[s];
    }
}