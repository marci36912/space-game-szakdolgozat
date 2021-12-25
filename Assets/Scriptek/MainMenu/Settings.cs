using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    [SerializeField] private Dropdown resolutionsDrop;
    [SerializeField] private GameObject[] menuk;
    private Resolution[] resolutions;
    private bool fullScreen;

    void Start()
    {
        Time.timeScale = 0;

        if (Screen.fullScreen == true) fullScreen = true;
        else fullScreen = false;

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
        Time.timeScale = 1;
        menuk[1].SetActive(false);
        menuk[0].SetActive(true);
    }
    public void performance()
    {
        QualitySettings.SetQualityLevel(0);
    }
    public void quality()
    {
        QualitySettings.SetQualityLevel(1);
    }
}
