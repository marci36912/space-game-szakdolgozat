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

    public void getHit(int hit, int irany)
    {
        elet -= hit;
        enemy.AddForce(new Vector2(irany, 0) * 3, ForceMode2D.Impulse);
    }

    private void dead()
    {
        Instantiate(death, enemy.transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
