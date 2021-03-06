using System.Collections;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Wincondition : MonoBehaviour
{
    [SerializeField] private GameObject[] player;
    [SerializeField] private TextMeshProUGUI winText;

    public static int P1Win = 0;
    public static int P2Win = 0;

    private bool first = true;

    private void LateUpdate()
    {
        player = player.Where(x => x != null).ToArray();

        if (player.Length <= 1)
        {
            StartCoroutine(win());
        }
    }

    private IEnumerator win()
    {
        winText.text = player[0].name + " WON";
        if (first)
        {
            winLogic();
            first = false;
        }

        yield return new WaitForSeconds(5);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void winLogic()
    {
        if (player[0].name == "P1")
        {
            P1Win++;
        }
        else
        {
            P2Win++;
        }
    }
}
