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
    [SerializeField] private float elete;
    private float maxElet = 100;

    private void Awake() {
        Instance = this;
    }
    void Start()
    {
        elete = maxElet;
    }

    private void Update()
    {
        elet();
    }

    private void elet()
    {
        hpText.text = elete.ToString();

        hpImg.color = Color.Lerp(ket, egy, elete/100);
    }

    public void sebzes(float dmg, float irany)
    {
        elete -= dmg;
        player.AddForce(new Vector2(0, 10), ForceMode2D.Impulse);
    }
}
