using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoltUI : MonoBehaviour
{
    [SerializeField] private Canvas UI;
    [SerializeField] private GameObject pauseMenu;

    public void Pistol()
    {
        if(KillCount.Instance.killed >= 0){
        SpaceGun.Instance.ActiveFegyver(0);
        }
    }

    public void AK()
    {
        if(KillCount.Instance.killed >= 20){
        SpaceGun.Instance.ActiveFegyver(1);
        KillCount.Instance.levasarolt(20);
        }
    }

    public void Shotgun()
    {
        if(KillCount.Instance.killed >= 35){
        SpaceGun.Instance.ActiveFegyver(2);
        KillCount.Instance.levasarolt(35);
        }
    }

    public void Health()
    {
        if(KillCount.Instance.killed >= 10){
            PlayerHP.Instance.hpFill();
            KillCount.Instance.levasarolt(10);
        }
    }
    public void exit()
    {
        UI.enabled = false;
        Time.timeScale = 1;
        pauseMenu.SetActive(true);
    }
}
