using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    [SerializeField] private GameObject[] playerek;

    public static bool first = false;

    private void Start()
    {
        playerek[1].GetComponent<Movement>().irany();

        if (first)
        {
            startGame();
        }
    }
    public void startGame()
    {
        int id = Random.Range(3, 8);
        SceneManager.LoadScene(id);
    }
}
