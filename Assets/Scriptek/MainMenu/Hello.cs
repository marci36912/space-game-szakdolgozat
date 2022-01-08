using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Hello : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI nev;

    private void LateUpdate()
    {
        nev.text = $"Hello, {Settings.Nev}!";
    }
}
