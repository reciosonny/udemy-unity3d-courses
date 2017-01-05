using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class HandleClicks : MonoBehaviour, IPointerClickHandler 
{
	public void OnPointerClick(PointerEventData EventData)
	{
		Debug.Log("You clicked: " + EventData.pointerPress.name);
	}
}
