using UnityEngine;
using System.Collections;
//---------------------------------------------------
public class RotateTo : MonoBehaviour 
{
	//---------------------------------------------------
	//Reference to target object
	public Transform Target = null;

	//Rotation speed
	public float RotSpeed = 30f;

	//Damped Speed
	public float Damping = 10f;
	//---------------------------------------------------
	// Update is called once per frame
	void Update () 
	{
		RotateTowardsWithDamp();
	}
	//---------------------------------------------------
	//Call this function in update to directly and continually look at a target position
	void LookAtImmediate()
	{
		transform.rotation = Quaternion.LookRotation(Target.position-transform.position,Vector3.up);
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
	//Spin object about axis
	void SpinObject(Vector3 AxisRot)
	{
		//Update rotation
		transform.rotation *= Quaternion.Euler(RotSpeed*Time.deltaTime*AxisRot.x,
												RotSpeed*Time.deltaTime*AxisRot.y,
												RotSpeed*Time.deltaTime*AxisRot.z);
	}
	//---------------------------------------------------
}
//---------------------------------------------------