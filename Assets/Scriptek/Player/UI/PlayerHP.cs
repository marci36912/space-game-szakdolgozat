using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHP : MonoBehaviour
{
    [SerializeField] private Slider hp;
    [SerializeField] private Color egy;
    [SerializeField] private Rigidbody2D player;
    private float elete;
    private float maxElet = 100;

    void Start()
    {
        elete = maxElet;
    }

    private void Update()
    {
        elet();
    }

    private void elet()
    {
        if (elete <= maxElet)
        {
            hp.maxValue = maxElet;
            hp.value = elete;

            hp.fillRect.GetComponentInChildren<Image>().color = egy;
        }
    }

    public void sebzes(float dmg, float irany)
    {
        elete -= dmg;
        player.AddForce(new Vector2(0, 10), ForceMode2D.Impulse);
    }
}
