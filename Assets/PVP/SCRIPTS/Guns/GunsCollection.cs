using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunsCollection : MonoBehaviour
{
    private static readonly List<GunsNEW> kollekcio = new List<GunsNEW>();
    private void Awake()
    {
        kollekcio.Add(new GunsNEW("Revolver", 1, 4, 0, 20, 1, 0.6f, false));         //0
        kollekcio.Add(new GunsNEW("Assault Rifle", 0.5f, 12, 0, 10,1, 0.45f, false)); //1     
        kollekcio.Add(new GunsNEW("Burst Rifle", 1.2f, 10, 0, 10, 3, 0.32f, false));  //2    
        kollekcio.Add(new GunsNEW("Charge Rifle", 2.4f, 2, 0, 100, 1, 0.32f, true));   //3   
        kollekcio.Add(new GunsNEW("Shotgun", 1.5f, 2, 0.6f, 13, 10, 0.25f, false));  //4
        kollekcio.Add(new GunsNEW("Sniper", 1.5f, 1, 0, 80, 1, 0.11f, false));       //5
    }

    public static GunsNEW returnGun(int n)
    {
        return kollekcio[n];
    }

    public static int getCount()
    {
        return kollekcio.Count;
    }
}
