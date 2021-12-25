using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] private GameObject[] menuk;
    public void startGame()
    {
        SceneManager.LoadScene(1);      
    }

    public void gameExit()
    {
        Application.Quit();
    }
    public void settings()
    {
        menuk[0].SetActive(false);
        menuk[1].SetActive(true);
    }
}
