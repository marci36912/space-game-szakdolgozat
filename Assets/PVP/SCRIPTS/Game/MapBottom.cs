using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapBottom : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.transform.GetComponentInChildren<HealthNEW>().sebzes(100);
    }
}
