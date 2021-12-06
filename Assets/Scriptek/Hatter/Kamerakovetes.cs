using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kamerakovetes : MonoBehaviour
{	
	[SerializeField] private Transform Player;
	private float delay = 1.5f;
	private float XSzel = 0;
	private float margin = 0.1f;

	void Start()
	{
		if (Player == null)
		{
			Player = GameObject.FindGameObjectWithTag("Player").transform;
		}
	}

	void Update()
	{
		if (Player)
		{
			float kamX = Player.position.x + XSzel;

			if (Mathf.Abs(transform.position.x - kamX) > margin)
				kamX = Mathf.Lerp(transform.position.x, kamX, 1 / delay * Time.deltaTime);

			transform.position = new Vector3(kamX, transform.position.y, transform.position.z);
		}
	}
}
