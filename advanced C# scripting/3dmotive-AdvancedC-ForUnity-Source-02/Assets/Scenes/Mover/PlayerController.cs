using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour 
{
	private CharacterController ThisController = null;
	private Transform ThisTransform = null;
	public float RotateSpeed = 90f;
	public float MaxSpeed = 50f;
	public float JumpForce = 50f;
	public float GroundedDist = 0.1f;
	public bool IsGrounded = false;
	private Vector3 Velocity = Vector3.zero;
	public LayerMask GroundLayer;

	// Use this for initialization
	void Awake () 
	{
		ThisController = GetComponent<CharacterController>();
		ThisTransform = GetComponent<Transform>();
	}

	// Update is called once per frame
	void FixedUpdate ()
	{
		float Horz = CrossPlatformInputManager.GetAxis("Horizontal");
		float Vert = CrossPlatformInputManager.GetAxis("Vertical");

		ThisTransform.rotation *= Quaternion.Euler(new Vector3(0,RotateSpeed * Time.deltaTime * Horz,0));

		//Calculate Move Dir
		Velocity.z = Vert * MaxSpeed;

		//Are we grounded?
		IsGrounded = (DistanceToGround() < GroundedDist) ? true : false;

		//Should we jump?
		if(CrossPlatformInputManager.GetAxisRaw("Jump")!=0 && IsGrounded)
			Velocity.y = JumpForce;

		//Apply gravity
		Velocity.y += Physics.gravity.y * Time.deltaTime;

		//Move
		ThisController.Move(ThisTransform.TransformDirection(Velocity) * Time.deltaTime);
	}

	public float DistanceToGround()
	{
		RaycastHit hit;
		float distanceToGround = 0;
		if(Physics.Raycast(ThisTransform.position, -Vector3.up, out hit, Mathf.Infinity, GroundLayer))
			distanceToGround = hit.distance;
		return distanceToGround;
	}
}
