using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ragdoll : MonoBehaviour
{
    public static Ragdoll Instance;

    [SerializeField] private Rigidbody2D[] rigidek;
    [SerializeField] private Collider2D[] colliderek;
    [SerializeField] private HingeJoint2D[] hingek;
    [SerializeField] private GameObject vall;
    
    private Animator anim;
    private Rigidbody2D player;

    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        anim = GetComponent<Animator>();
        player = GetComponent<Rigidbody2D>();
    }

    public void ragdollBe()
    {
        Time.timeScale = 0.3f;

        anim.enabled = false;

        vall.SetActive(false);

        player.bodyType = RigidbodyType2D.Kinematic;
        player.freezeRotation = false;

        foreach (var rigid in rigidek)
        {
            rigid.bodyType = RigidbodyType2D.Dynamic;
        }
        foreach (var collider in colliderek)
        {
            collider.enabled = true;
        }
        foreach (var hinge in hingek)
        {
            hinge.enabled = true;
        }

        GetComponent<Mozgas>().enabled = false;
        GetComponent<SpaceGun>().enabled = false;
    }
}
