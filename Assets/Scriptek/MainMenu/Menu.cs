using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] private Canvas[] menuk;
    [SerializeField] private Slider volume;

    private void Start()
    {
        volume.value = AudioListener.volume;
    }
    public void startGame()
    {
        SceneManager.LoadScene(1);      
    }

    public void gameExit()
    {
        PlayerData.saveData();
        Application.Quit();
    }
    public void settings()
    {
        menuk[0].enabled = false;
        menuk[1].enabled = true;
    }

    public void soundVolume(float n)
    {
        AudioListener.volume = n;
    }
}
