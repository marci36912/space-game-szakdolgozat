using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zene : MonoBehaviour
{
    [SerializeField] private AudioSource mainMusic;

    private void Start()
    {
        mainMusic.volume = 0;
        mainMusic.Play();
        mainMusic.loop = true;
    }
    private void FixedUpdate()
    {
        if (mainMusic.volume != 1)
        {
            mainMusic.volume += 0.0025f;
        }
    }
}
