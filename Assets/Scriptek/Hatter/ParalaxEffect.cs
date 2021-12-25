using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParalaxEffect : MonoBehaviour
{  
	[SerializeField] private GameObject kamera;
	[SerializeField] private float effektSzorzo;

	private float hossz;
	private float kezdesP;

	void Start () {
		kezdesP = transform.position.x;
		hossz = GetComponent<SpriteRenderer>().bounds.size.x;
	}
	
	void FixedUpdate () {
		float dist = (kamera.transform.position.x*effektSzorzo);

		transform.position = new Vector3(kezdesP + dist, transform.position.y, transform.position.z);		
	}
}
