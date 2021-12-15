using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CDUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI ui;
    private static float time;
    
    private void Start() {
        ui.text = " ";
    }
    void Update()
    {
        if(time <= 0)
        {
            ui.enabled = false;
        }
        if(time > 0)
        {
            ui.enabled = true;
            time -= Time.deltaTime;
            ui.text = (Mathf.Round(time * 100) / 100).ToString();
        }
    }

    public static void timeSet()
    {
        time = 11;
    }
}
