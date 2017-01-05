//Programmed by Alan Thorn 2015
//------------------------------
using UnityEngine;
using System.Collections;
//------------------------------
public class Ammo : MonoBehaviour
{
	public float Damage = 100f;
	public float LifeTime = 2f;
	//------------------------------
	void OnEnable()
	{
		CancelInvoke();
		Invoke("Die", LifeTime);
	}
	//------------------------------
	// Update is called once per frame
	void OnTriggerEnter(Collider Col)
	{
		Die ();
	}
	//------------------------------
	void Die()
	{
		CancelInvoke();
		gameObject.SetActive(false);
	}

	//------------------------------
}
//------------------------------