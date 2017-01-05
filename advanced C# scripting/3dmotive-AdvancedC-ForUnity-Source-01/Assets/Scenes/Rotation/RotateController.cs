using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;
//---------------------------------------------------
public class RotateController : MonoBehaviour
{
	//---------------------------------------------------
	private Transform ThisTransform = null;
	public float RotSpeed = 90f;
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

		//Rotating on global and local axes
		ThisTransform.Rotate(0f,Horz * Time.deltaTime * RotSpeed,0f,Space.World);
		ThisTransform.Rotate(Vert * Time.deltaTime * RotSpeed,0f,0f);
	}
	//---------------------------------------------------
}
//---------------------------------------------------