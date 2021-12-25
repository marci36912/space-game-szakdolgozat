using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerHP : MonoBehaviour
{
    public static PlayerHP Instance;

    [SerializeField] private SpriteRenderer hpImg;
    [SerializeField] private TextMeshProUGUI hpText;
    [SerializeField] private Color egy;
    [SerializeField] private Color ket;
    [SerializeField] private Rigidbody2D player;
    [SerializeField] private Canvas deathmenu;
    [SerializeField] private GameObject pauseMenu;
    private float elete;   
    private float maxElet;

    private void Awake() {
        Instance = this;
    }
    void Start()
    {
        maxElet = 100;
        elete = maxElet;
    }

    private void Update()
    {
        elet();

        if (elete <= 0)
        {
            Ragdoll.Instance.ragdollBe();
            pauseMenu.SetActive(false);
            deathmenu.enabled = true;
        }
    }

    private void elet()
    {
        elete = Mathf.Clamp(elete, 0, maxElet);

        hpText.text = elete.ToString();

        hpImg.color = Color.Lerp(ket, egy, elete/100);
    }

    public void sebzes(float dmg, float irany)
    {
        elete -= dmg;
        player.AddForce(new Vector2(0, 10), ForceMode2D.Impulse);
    }

    public void hpFill()
    {
        elete = maxElet;
    }
}
