using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BestRun : MonoBehaviour
{
    private TextMeshProUGUI text;
    private void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
    }
    private void LateUpdate()
    {
        text.text = "Most kills in one run: " + KillCount.best;
    }
}
