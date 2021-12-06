using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LoszerUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI loszer;
    void LateUpdate()
    {
        if(SpaceGun.aktivFegyver.GetNev() == "Shotgun")
        {
        loszer.text = (SpaceGun.Instance.Tar()/6) + "/" + (SpaceGun.aktivFegyver.GetTar()/6);
        }
        else
        {
        loszer.text = SpaceGun.Instance.Tar() + "/" + SpaceGun.aktivFegyver.GetTar();
        }
    }
}
