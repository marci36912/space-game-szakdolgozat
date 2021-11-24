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
        loszer.text = SpaceGun.Instance.Tar() + "/" + SpaceGun.Instance.maxTar();
    }
}
