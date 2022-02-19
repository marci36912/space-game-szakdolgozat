using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthNEW : MonoBehaviour
{
    /*TODO
     * random fegyver az egbol!!!!
     */
    [SerializeField] private SpriteRenderer hpbar;
    [SerializeField] private Color[] szinek;
    [SerializeField] private ParticleSystem onDeath;
    private float health = 100;
    private GameObject me;

    private void Start()
    {
        me = transform.parent.gameObject;
    }
    private void Update()
    {
        hpcolor();
        death();
    }
    
    private void hpcolor()
    {
        health = Mathf.Clamp(health, 0, 100);
        hpbar.color = Color.Lerp(szinek[1], szinek[0], health / 100);
    }
    private void death()
    {
        if (health == 0)
        {
            Instantiate(onDeath, transform.position, Quaternion.identity);
            Destroy(me);
        }
    }

    public void sebzes(float dmg)
    {
        health -= dmg;
    }
}
