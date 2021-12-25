using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathMenu : MonoBehaviour
{
    public void mainmenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
