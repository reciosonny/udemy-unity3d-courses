using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBullet : MonoBehaviour {

	public float speed = 1f;

	// Use this for initialization
	void Start ()	
	{
		Destroy(gameObject, 5f); //Delete the bullet after 5 seconds
	}

	void Update ()	
	{
		transform.Translate(0, 0, speed);
	}

	void OnTriggerEnter(Collider other) {
		Debug.Log ("just collided something...");
		if (other.gameObject.CompareTag("Zombie")) {
			Destroy (other.gameObject);
			Destroy (this.gameObject);
//			other.gameObject.SetActive(false);
		}
	}
}
