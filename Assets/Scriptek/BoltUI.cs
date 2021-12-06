using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoltUI : MonoBehaviour
{
    [SerializeField] private Canvas UI;
    public void Pistol()
    {
        SpaceGun.Instance.ActiveFegyver(0);
    }

    public void AK()
    {
        SpaceGun.Instance.ActiveFegyver(1);
    }

    public void Shotgun()
    {
        SpaceGun.Instance.ActiveFegyver(2);
    }

    public void exit()
    {
        UI.enabled = false;
        Time.timeScale = 1;
    }
}
