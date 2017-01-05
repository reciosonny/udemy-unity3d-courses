//---------------------------------------------------
using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;
//---------------------------------------------------
public class RotateControllerManual : MonoBehaviour
{
	//---------------------------------------------------
	public float RotSpeed = 90f;
	public float Damping = 10f;
	private float RotX = 0f;
	private float RotY = 0f;
	private Transform ThisTransform = null;
	private Quaternion DestRot = Quaternion.identity;
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
		float Horz = CrossPlatformInputManager.GetAxis("Horizontal");
		float Vert = CrossPlatformInputManager.GetAxis("Vertical");

		RotX += Vert * Time.deltaTime * RotSpeed;
		RotY += Horz * Time.deltaTime * RotSpeed;

		//Build quaternions
		Quaternion YRot = Quaternion.Euler(0f,RotY,0f);
		DestRot = YRot * Quaternion.Euler(RotX,0f,0f);

		ThisTransform.rotation = Quaternion.Slerp(transform.rotation, DestRot, 1f - (Time.deltaTime*Damping));
	}
	//---------------------------------------------------
}
//---------------------------------------------------