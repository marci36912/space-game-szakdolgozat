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
        if(time > 0)
        {
            time /= Time.deltaTime;
            ui.text = time.ToString();
        }
    }

    public static void timeSet()
    {
        time = 10;
    }
}
