//---------------------------------------------------
using UnityEngine;
using System.Collections;
//---------------------------------------------------
public class Mover : MonoBehaviour 
{
	public float MaxSpeed = 10f;
	private Transform ThisTransform = null;
	//---------------------------------------------------
	// Use this for initialization
	void Awake () 
	{
		ThisTransform = GetComponent<Transform>();
	}
	//---------------------------------------------------
	// Update is called once per frame
	void Update () 
	{
		ThisTransform.position += ThisTransform.forward * MaxSpeed * Time.deltaTime;
	}
	//---------------------------------------------------
}
//---------------------------------------------------