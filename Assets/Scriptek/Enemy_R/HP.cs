using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HP : MonoBehaviour
{
    [SerializeField] private ParticleSystem death;
    [SerializeField] private float eletMax = 100;
    private float elet;
    private Rigidbody2D enemy;

    public enemyHPCsik hpcs;


    private void Start()
    {
        elet = eletMax;

        hpcs.elet(elet,eletMax);
        enemy = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        hpcs.elet(elet, eletMax);
        if (elet <= 0)
        {
            dead();
        }
    }

    public void getHit(int hit)
    {       
        elet -= hit;
    }

    private void dead()
    {
        Instantiate(death, enemy.transform.position, Quaternion.identity);
        KillCount.Instance.kill();
        ufo.Instance.enemyDeath();
        Destroy(gameObject);
    }
}
