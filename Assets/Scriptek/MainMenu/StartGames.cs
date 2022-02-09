using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGames : MonoBehaviour
{
    [SerializeField] private Canvas[] menuk;

    public void startSingle() 
    {
        SceneManager.LoadScene(1);
    }
    public void startPVP()
    {
        SceneManager.LoadScene(2);
    }
    public void backToM()
    {
        menuk[0].enabled = true;
        menuk[1].enabled = false;
        menuk[2].enabled = false;
    }
}
