using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pewpew : MonoBehaviour
{
    [SerializeField] private Rigidbody2D loszer;
    [SerializeField] private ParticleSystem hit;
    private GameObject sp2;
    private Transform sp;
    private Vector3 irany;
    private float spread;
    private float velocity;

    void Start()
    {
        sp = loszer.transform;
        sp2 = GameObject.FindWithTag("sp2");
        spread = SpaceGun.aktivFegyver.GetSpread();
        velocity = SpaceGun.aktivFegyver.GetBuVell();

        loszer.rotation = szogFloat();
        irany = szogSp().normalized;

        loszer.velocity = irany * velocity;

        Destroy(this.gameObject, 3f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

         HP enemy = collision.GetComponent<HP>();

         if (enemy != null)
         {
            Destroy(this.gameObject);
            Instantiate(hit, transform.position, Quaternion.LookRotation(szogForditott()));
            enemy.getHit(SpaceGun.aktivFegyver.GetSebzes());
         }
        if (collision.name.Equals("platform"))
        {
            Destroy(this.gameObject);
            Instantiate(hit, transform.position, Quaternion.LookRotation(szogForditott()));
        }      
    }

    #region szogek


    private Vector3 szogSp()
    {
        Vector3 eger = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 rotate = new Vector3(sp2.transform.position.x + Random.Range(-spread, spread), sp2.transform.position.y + Random.Range(-spread, spread), sp2.transform.position.z) - sp.position;
        return rotate;
    }
    private Vector3 szog()
    {
        Vector3 eger = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 rotate = new Vector3(eger.x + Random.Range(-spread, spread), eger.y + Random.Range(-spread, spread), eger.z) - sp.position;
        return rotate;
    }

    private Vector3 szogForditott()
    {
        Vector3 eger = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 rotate =  sp.position - eger;
        return rotate;
    }

    private float szogFloat()
    {
        Vector2 tmp = szog();
        float szogR = Mathf.Atan2(tmp.y, tmp.x) * Mathf.Rad2Deg;

        return szogR;
    }

    #endregion
}
