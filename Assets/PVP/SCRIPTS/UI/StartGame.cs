using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    [SerializeField] private List<GameObject> objektek;
    [SerializeField] private GameObject[] playerek;
    [SerializeField] private Transform[] spawnokP1;
    [SerializeField] private Transform[] spawnokP2;
    [SerializeField] private GameObject canvas;
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private TextMeshProUGUI stats;

    [SerializeField] private Scene[] scenes;

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
        SceneManager.LoadScene(Random.Range(3,5));
        /*foreach (var item in objektek)
        {
            item.SetActive(true);
        }

        for (int i = 0; i < playerek.Length; i++)
        {
            playerek[i].GetComponent<Shooting>().enabled = true;
            playerek[i].GetComponent<Movement>().enabled = true;
        }

        setPos();

        canvas.SetActive(false);
        pauseMenu.SetActive(true);
        stats.text = $"P1 WINS: {Wincondition.P1Win}\nP2 WINS: {Wincondition.P2Win}";
        Time.timeScale = 1;
        first = true;
        */
    }

    private void setPos()
    {
        Camera.main.transform.position = new Vector3(0, 0, -10);

        playerek[0].transform.position = spawnokP1[Random.Range(0, spawnokP1.Length - 1)].position;
        playerek[1].transform.position = spawnokP2[Random.Range(0, spawnokP2.Length - 1)].position;
    }
}
