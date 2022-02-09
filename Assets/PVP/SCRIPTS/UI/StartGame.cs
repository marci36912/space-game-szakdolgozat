using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartGame : MonoBehaviour
{
    [SerializeField] private List<GameObject> objektek;
    [SerializeField] private GameObject[] playerek;
    [SerializeField] private Transform[] spawnok;
    [SerializeField] private GameObject canvas;


    private void Start()
    {
        playerek[1].GetComponent<Movement>().irany();
    }
    public void startGame()
    {
        foreach (var item in objektek)
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
        Time.timeScale = 1;
    }

    private void setPos()
    {
        Camera.main.transform.position = new Vector3(0, 0, -10);

        for (int i = 0; i < spawnok.Length; i++)
        {
            playerek[i].transform.position = spawnok[i].transform.position;
        }
    }
}
