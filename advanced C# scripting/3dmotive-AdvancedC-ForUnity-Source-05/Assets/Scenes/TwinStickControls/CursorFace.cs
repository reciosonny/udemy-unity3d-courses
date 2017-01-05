using UnityEngine;
using System.Collections;

public class CursorFace : MonoBehaviour 
{
	private Transform ThisTransform = null;
	// Use this for initialization
	void Awake () 
	{
		ThisTransform = GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		Vector3 MousePosWorld = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,
																Input.mousePosition.y, 0f));

		MousePosWorld = new Vector3(MousePosWorld.x, ThisTransform.position.y, MousePosWorld.z);

		Vector3 LookDirection = MousePosWorld - ThisTransform.position;

		ThisTransform.localRotation = Quaternion.LookRotation(LookDirection.normalized, Vector3.up);
	}
}
