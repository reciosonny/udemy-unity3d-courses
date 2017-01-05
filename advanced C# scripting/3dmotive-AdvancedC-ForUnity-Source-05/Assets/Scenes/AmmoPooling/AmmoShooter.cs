using UnityEngine;
using System.Collections;

public class AmmoShooter : MonoBehaviour 
{
	private bool CanFire = true;
	public Transform[] TurretTransforms;
	public float ReloadDelay = 0.1f;

	// Update is called once per frame
	void Update () 
	{
		//Check fire control
		if(Input.GetButtonDown("Fire1") && CanFire)
		{
			foreach(Transform T in TurretTransforms)
				AmmoManager.SpawnAmmo(T.position, T.rotation);

			CanFire = false;
			Invoke ("EnableFire", ReloadDelay);
		}
	}

	void EnableFire()
	{
		CanFire = true;
	}
}
