using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class TerrainHover : MonoBehaviour 
{
	private Transform ThisTransform = null;
	public float MaxSpeed = 10f;
	public float DistanceFromGround = 2f;
	private Vector3 DestUp = Vector3.zero;
	public float AngleSpeed = 5f;

	// Use this for initialization
	void Awake () 
	{
		ThisTransform = GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		float Horz = CrossPlatformInputManager.GetAxis("Horizontal");
		float Vert = CrossPlatformInputManager.GetAxis("Vertical");

		Vector3 NewPos = ThisTransform.position;
		NewPos += ThisTransform.forward * Vert * MaxSpeed * Time.deltaTime;
		NewPos += ThisTransform.right * Horz * MaxSpeed * Time.deltaTime;

		RaycastHit Hit;
		if(Physics.Raycast(ThisTransform.position, -Vector3.up, out Hit))
		{
			NewPos.y = (Hit.point + Vector3.up * DistanceFromGround).y;
			DestUp = Hit.normal;
		}

		ThisTransform.position = NewPos;
		ThisTransform.up = Vector3.Slerp(ThisTransform.up, DestUp, AngleSpeed*Time.deltaTime);
	}
}
