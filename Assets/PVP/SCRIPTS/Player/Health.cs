using UnityEngine;
using TMPro;
using System;

public class Health : MonoBehaviour
{
    [SerializeField] private Transform tf;
    [SerializeField] private ParticleSystem onDeath;

    private GameObject me;
    private TextMeshPro hpbar;
    private int health;
    private Quaternion rotation;

    private void Awake()
    {
        rotation = transform.rotation;
    }
    
    private void Start()
    {
        var me2 = transform.parent.gameObject;
        me = me2.transform.parent.gameObject;
        hpbar = GetComponent<TextMeshPro>();
        health = 5;
    }
    private void FixedUpdate()
    {
        hpbar.text = new string('-', health);

        hpbar.transform.position = tf.position;

        if (health == 0)
        {
            death();
        }
    }

    private void death()
    {
        Instantiate(onDeath, transform.position, Quaternion.identity);
        Destroy(me);
    }

    private void LateUpdate()
    {
        transform.rotation = rotation;
    }

    public void getHit()
    {
        health--;
    }
}
