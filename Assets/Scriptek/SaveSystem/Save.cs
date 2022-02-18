using UnityEngine;

[System.Serializable]
public class Save
{
    public string nev;
    public int legjobbKor;
    public int screenHeight;
    public int screenWidth;
    public bool fullScreen;
    public int graficsQuality;
    public float volume;

    public Save(string nev, int legjobb, Resolution res, bool fullscrn, int quality, float volume)
    {
        this.nev = nev;
        this.legjobbKor = legjobb;
        this.screenHeight = res.height;
        this.screenWidth = res.width;
        this.fullScreen = fullscrn;
        this.graficsQuality = quality;
        this.volume = volume;
    }
}
