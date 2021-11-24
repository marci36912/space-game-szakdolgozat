using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KarMozgas : MonoBehaviour
{
    [SerializeField] private Transform kar;
    [SerializeField] private Transform karText;
    [SerializeField] private Transform player;
    [SerializeField] private Transform sp;
    private Vector3 egerKep;
    private Vector2 eger;
    private float egerRad;
    private bool fordit = false;


    void Update()
    {
        karForditas();

        if (Mathf.Abs(egerRad) < 90 && fordit == false)
        {
            testForgatas();
        }
        else if(Mathf.Abs(egerRad) > 90 && fordit == true)
        {
            testForgatas();
        }
    }

    private void karForditas()
    {
        egerKep = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        eger = sp.position - egerKep;
        egerRad = Mathf.Atan2(eger.y, eger.x) * Mathf.Rad2Deg;


        kar.eulerAngles = new Vector3(0, 0, egerRad + 180);
    }

    private void testForgatas()
    {
        fordit = !fordit;

        karText.Rotate(0f, 180f, 0f);
        player.Rotate(0f, 180f, 0f);
    }
}
