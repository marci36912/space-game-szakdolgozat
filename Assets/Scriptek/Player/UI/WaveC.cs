using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WaveC : MonoBehaviour
{    
    [SerializeField] private TextMeshProUGUI wave;
    void Update()
    {
        wave.text = "round " + ufo.waveCount;
    }
}
