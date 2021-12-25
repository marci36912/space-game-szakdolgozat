using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class KillCount : MonoBehaviour
{
    public static KillCount Instance;

    [SerializeField] private TextMeshProUGUI kc;
    [HideInInspector] public int killed;


    private void Awake()
    {
        Instance = this;
    }
    private void Start() {
        killed = 0;
    }
    private void Update()
    {
        kc.text = $"X{killed}";
    }

    public void kill()
    {
        killed++;
    }

    public void levasarolt(int osszeg){
        killed -= osszeg;
    }
}
