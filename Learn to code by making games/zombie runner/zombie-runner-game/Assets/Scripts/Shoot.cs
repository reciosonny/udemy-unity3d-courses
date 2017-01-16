using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	public GameObject bullet;
	public GameObject bulletHole;
	public float delayTime = 0.5f;

	private float counter = 0;

	void FixedUpdate ()	
	{
		if(Input.GetKey(KeyCode.Mouse0) && counter > delayTime)
		{
			Instantiate(bullet, transform.position, transform.rotation);
			GetComponent<AudioSource> ().Play ();
			//			audio.Play();
			counter = 0;

			RaycastHit hit;
			Ray ray = new Ray(transform.position, transform.forward);
			if(Physics.Raycast(ray, out hit, 100f))
			{
				Debug.Log ("Zombie hit");
//				Instantiate(bulletHole, hit.point, Quaternion.FromToRotation(Vector3.up, hit.normal));
			}
						
		}
		counter += Time.deltaTime;
	}


}
