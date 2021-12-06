using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class KillCount : MonoBehaviour
{
    public static KillCount Instance;

    [SerializeField] private TextMeshProUGUI kc;
    private int killed = 0;


    private void Awake()
    {
        Instance = this;
    }
    private void Update()
    {
        kc.text = $"X{killed}";
    }

    public void kill()
    {
        killed++;
    }
}
