using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathMenu : MonoBehaviour
{
    public void mainmenu()
    {
        PlayerData.saveData();
        SceneManager.LoadScene("MainMenu");
    }
    public void retry()
    {
        PlayerData.saveData();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
