//------------------------------------------
using UnityEngine;
using System.Collections;
//------------------------------------------
public class InventoryItem : MonoBehaviour
{
	//------------------------------------------
	public enum ITEMTYPE {SPHERE, BOX, CYLINDER};
	public ITEMTYPE Type;
	public Sprite GUI_Icon = null;
	//------------------------------------------
	void OnTriggerEnter(Collider Col)
	{
		if(!Col.CompareTag("Player"))
			return;

		//Add this item to the inventory
		Inventory.AddItem(gameObject);
	}
	//------------------------------------------
}
//------------------------------------------