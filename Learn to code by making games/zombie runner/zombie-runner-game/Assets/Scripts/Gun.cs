using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour {


	public Rigidbody projectile;
	float speed = 20f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetButton ("Fire1")) {

			var clone = Instantiate(projectile, transform.position, transform.rotation);
//			clone.velocity = transform.TransformDirection(new Vector3 (-10, -2, speed)); //transform.forward;
			clone.velocity = transform.forward;

			Destroy (clone.gameObject, 3);
		}

	}
}
