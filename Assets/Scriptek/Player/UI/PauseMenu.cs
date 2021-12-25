using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private Canvas pauseMenu;
    private bool paused;
    private void Start()
    {
        paused = false;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) 
        {
            if (!paused)
            {
                SpaceGun.Instance.cd += 0.5f;
                Time.timeScale = 0;
                pauseMenu.enabled = true;
                paused = true;
            }
            else if (paused)
            {
                resume();
            }
        }
    }

    public void resume()
    {
        pauseMenu.enabled = false;
        Time.timeScale = 1;
        paused = false;
    }
    public void mainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
    public void exit()
    {
        Application.Quit();
    }
}
