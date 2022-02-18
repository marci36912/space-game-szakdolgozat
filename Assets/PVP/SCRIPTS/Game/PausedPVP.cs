using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class PausedPVP : MonoBehaviour
{
    [SerializeField] private Canvas menu;
    [SerializeField] private TextMeshProUGUI stats;
    private bool pausedRN = false;


    private void Start()
    {
        stats.text = $"P1 WINS: {Wincondition.P1Win}\nP2 WINS: {Wincondition.P2Win}";
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pause();
        }
    }

    private void pause()
    {
        if (pausedRN)
        {
            Time.timeScale = 0;
            menu.enabled = true;
            pausedRN = !pausedRN;
        }
        else
        {
            Time.timeScale = 1;
            menu.enabled = false;
            pausedRN = !pausedRN;
        }
    }

    public void resume()
    {
        pause();
    }

    public void mainm()
    {
        SceneManager.LoadScene(0);
    }

    public void quit()
    {
        Application.Quit();
    }
}
