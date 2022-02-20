using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tancsiHotkey : MonoBehaviour
{
    [SerializeField] private KeyCode[] gombok;
    [SerializeField] private Animator szoveg;
    [SerializeField] private GameObject szovegObj;
    void Start()
    {
        transform.position = new Vector3(0, -20001, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(gombok[0]) && Input.GetKey(gombok[1]))
        {
            szovegObj.SetActive(true);
            szoveg.SetBool("lenyomva", true);
        }
    }
}
