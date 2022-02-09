using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    [SerializeField] private Dropdown resolutionsDrop;
    [SerializeField] private Canvas[] menuk;
    [SerializeField] private InputField input;
    [SerializeField] private Toggle fulscreenToggle;
    private Resolution[] resolutions;
    private bool fullScreen;

    public static string Nev;

    void Start()
    {
        if (Nev == null)
        {
            input.text = "Player";
            Nev = input.text;
        }
        else
        {
            input.text = Nev;
        }

        fullScreen = Screen.fullScreen;
        fulscreenToggle.isOn = fullScreen;

        resolutions = Screen.resolutions;
        List<string> res = new List<string>();
        string tmp = "";

        resolutionsDrop.ClearOptions();
        int aktiv = 0;

        for (int i = 0; i < resolutions.Length; i++)
        {
            tmp = resolutions[i].width + "X" + resolutions[i].height;
            res.Add(tmp);

            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                aktiv = i;
            }
        }

        resolutionsDrop.AddOptions(res);
        resolutionsDrop.value = aktiv;
        resolutionsDrop.RefreshShownValue();
    }


    public void setResouliton(int n)
    {
        Resolution resolution = resolutions[n];
        Screen.SetResolution(resolution.width, resolution.height, fullScreen);
    }
    public void setFullScreen(bool b)
    {
        fullScreen = b;
        Screen.fullScreen = b;
    }
    public void back()
    {
        PlayerData.saveData();
        menuk[1].enabled = false;
        menuk[2].enabled = false;
        menuk[0].enabled = true;
    }
    public void performance()
    {
        QualitySettings.SetQualityLevel(0);
    }
    public void quality()
    {
        QualitySettings.SetQualityLevel(1);
    }

    public static void saveName(string name)
    {
        Nev = name;
    }
}
