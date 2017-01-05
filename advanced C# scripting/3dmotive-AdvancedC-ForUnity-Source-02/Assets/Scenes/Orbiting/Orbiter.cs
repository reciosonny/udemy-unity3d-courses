//---------------------------------------------------
using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;
//---------------------------------------------------
public class Orbiter : MonoBehaviour 
{
	//---------------------------------------------------
	public Transform Pivot = null;
	private Transform ThisTransform = null;
	private Quaternion DestRot = Quaternion.identity;
	//Distance to maintain from pivot
	public float PivotDistance = 5f;
	public float RotSpeed = 10f;
	private float RotX = 0f;
	private float RotY = 0f;
	//---------------------------------------------------
	void Awake()
	{
		ThisTransform = GetComponent<Transform>();
	}
	//---------------------------------------------------
	void Update()
	{
		float Horz = CrossPlatformInputManager.GetAxis("Horizontal");
		float Vert = CrossPlatformInputManager.GetAxis("Vertical");

		RotX += Vert * Time.deltaTime * RotSpeed;
		RotY += Horz * Time.deltaTime * RotSpeed;

		Quaternion YRot = Quaternion.Euler(0f,RotY,0f);
		DestRot = YRot * Quaternion.Euler(RotX,0f,0f);

		ThisTransform.rotation = DestRot;

		//Adjust position
		ThisTransform.position = Pivot.position + ThisTransform.rotation * Vector3.forward * -PivotDistance;
	}
	//---------------------------------------------------
}
//---------------------------------------------------