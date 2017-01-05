using UnityEngine;
using System.Collections;

public class RotateTo : MonoBehaviour 
{
	private Transform ThisTransform = null;
	public float RotSpeed = 90f;

	public Transform Target = null;

	public float Damping = 55f;
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
		//RotateTowards();
		RotateTowardsWithDamp();
	}
	//---------------------------------------------------
	void RotateTowards()
	{
		//Get look to rotation
		Quaternion DestRot = Quaternion.LookRotation(Target.position-transform.position,Vector3.up);

		//Update rotation
		transform.rotation = Quaternion.RotateTowards(transform.rotation, DestRot, RotSpeed * Time.deltaTime);
	}
	//---------------------------------------------------
	void RotateTowardsWithDamp()
	{
		//Get look to rotation
		Quaternion DestRot = Quaternion.LookRotation(Target.position-transform.position,Vector3.up);

		//Calc smooth rotate
		Quaternion smoothRot = Quaternion.Slerp(transform.rotation, DestRot, 1f - (Time.deltaTime*Damping));

		//Update Rotation
		transform.rotation = smoothRot;
	}
	//---------------------------------------------------
}
