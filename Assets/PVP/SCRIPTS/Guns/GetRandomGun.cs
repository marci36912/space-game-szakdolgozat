using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetRandomGun : MonoBehaviour
{
    [SerializeField] private int id;
    private SpriteRenderer sr;
    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        Invoke("destroyMe", 10f);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            collision.transform.GetComponent<Shooting>().getDetails(GunsCollection.returnGun(id));
            var tmp = collision.transform.Find("gun").GetComponent<SpriteRenderer>();
            tmp.sprite = sr.sprite;
            Destroy(this.gameObject);
        }
    }

    private void destroyMe()
    {
        Destroy(this.transform.gameObject);
    }
}
