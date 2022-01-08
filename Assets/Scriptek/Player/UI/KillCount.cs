using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class KillCount : MonoBehaviour
{
    public static KillCount Instance;

    [SerializeField] private TextMeshProUGUI kc;
    [SerializeField] private AudioSource robotDeath;
    [HideInInspector] public int killed;
    [HideInInspector] public static int best;
    private int tmp;

    private void Awake()
    {
        Instance = this;
    }
    private void Start() {
        killed = 0;
        tmp = 0;
    }
    private void Update()
    {
        kc.text = $"X{killed}";

        if (tmp > best)
        {
            best = tmp;
        }
    }

    public void kill()
    {
        robotDeath.Play();
        tmp++;
        killed++;
    }

    public void levasarolt(int osszeg){
        killed -= osszeg;
    }
}
