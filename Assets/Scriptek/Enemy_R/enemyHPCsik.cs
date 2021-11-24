using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemyHPCsik : MonoBehaviour
{
    [SerializeField] private Slider hp;
    [SerializeField] private Color egy;
    [SerializeField] private Color ketto;
    [SerializeField] private Vector3 magassag;

    void Update()
    {
        hp.transform.position = Camera.main.WorldToScreenPoint(transform.parent.position + magassag);
    }

    public void elet(float elet, float maxElet)
    {
        if (elet < maxElet)
        {
            hp.gameObject.SetActive(true);
            hp.maxValue = maxElet;
            hp.value = elet;

            hp.fillRect.GetComponentInChildren<Image>().color = Color.Lerp(egy, ketto, hp.normalizedValue);
        }
    }
}
