//---------------------------------------------------
using UnityEngine;
using System.Collections;
//---------------------------------------------------
public class GizmoLine : MonoBehaviour
{
	//---------------------------------------------------
	public Transform LineStart = null;
	public Transform LineEnd = null;
	//---------------------------------------------------
	void OnDrawGizmos()
	{
		//If start and end are not valid, then exit
		if(LineStart==null || LineEnd==null)return;

		Gizmos.color = Color.green;
		Gizmos.DrawLine(LineStart.position, LineEnd.position);
	}
	//---------------------------------------------------
}
//---------------------------------------------------