using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    private static PlayerData data;
    private static Save adatok;


    private void Awake()
    {
        adatok = PlayerSave.load();

        if (adatok == null)
        {
            KillCount.best = 0;
            adatok = new Save(Settings.Nev, KillCount.best, Screen.currentResolution, Screen.fullScreen, QualitySettings.GetQualityLevel(), AudioListener.volume);
        }
        else
        {
            loadSaved();
        }
    }

    private void loadSaved()
    {
        Settings.Nev = adatok.nev;
        KillCount.best = adatok.legjobbKor;
        //Screen.SetResolution(adatok.screenWidth, adatok.screenHeight, adatok.fullScreen);
        QualitySettings.SetQualityLevel(adatok.graficsQuality);
        AudioListener.volume = adatok.volume;
    }

    public static void saveData()
    {
        adatok.nev = Settings.Nev;
        adatok.legjobbKor = KillCount.best;
        adatok.screenWidth = Screen.currentResolution.width;
        adatok.screenHeight = Screen.currentResolution.height;
        adatok.fullScreen = Screen.fullScreen;
        adatok.graficsQuality = QualitySettings.GetQualityLevel();
        adatok.volume = AudioListener.volume;

        PlayerSave.SavePlayer(adatok);
    }

    private void Start()
    {
        DontDestroyOnLoad(this);

        if (data == null)
        {
            data = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
