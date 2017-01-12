using UnityEngine;
using System.Collections;

public class DisplaceObject : MonoBehaviour 
{
	public float DisplaceSpeed = 2f;
	private Transform ThisTransform = null;

	[SerializeField]
	private Vector3 LocalForward;
	[SerializeField]
	private Vector3 TransformForward;

	// Use this for initialization
	void Awake () 
	{
		ThisTransform = GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		LocalForward = Vector3.forward;
		TransformForward = ThisTransform.forward;

//		ThisTransform.position += ThisTransform.forward * DisplaceSpeed * Time.deltaTime;

		Vector3 LocalSpaceDisplacement = Vector3.forward * DisplaceSpeed * Time.deltaTime;
		/*note: the codes here are interchangeable. Comment out one of them to see how it works.*/
		//Vector3 WorldSpaceDisplacement = ThisTransform.TransformDirection(LocalSpaceDisplacement); //displacement in local space
		Vector3 WorldSpaceDisplacement = ThisTransform.rotation * LocalSpaceDisplacement; //conversion from local space to world space using quaternions(rotation)
		/*END*/

		ThisTransform.position += WorldSpaceDisplacement;


	}
}
