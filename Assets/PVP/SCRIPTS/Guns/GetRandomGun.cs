using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetRandomGun : MonoBehaviour
{
    [SerializeField] private int id;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            collision.transform.GetComponent<Shooting>().getDetails(GunsCollection.returnGun(id));
            Destroy(this.gameObject);
        }
    }
}
