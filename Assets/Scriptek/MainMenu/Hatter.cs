using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hatter : MonoBehaviour
{
    private void Update()
    {
		transform.position -= new Vector3(Time.deltaTime, 0, 0);

        if (transform.position.x < -12)
        {
			transform.position = new Vector2(20,transform.position.y);
        }
    }
}
