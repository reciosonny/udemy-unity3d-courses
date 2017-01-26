using System.Collections;
using System.Collections.Generic;
using System.Reflection.Emit;
using UnityEngine;
using UnityEngine.UI;

public class AddInventory : MonoBehaviour {
    public Button btnInventory;
    public Transform panelInventory;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private int count = 0;
    public void OnClick() {
        count += 1;
        Debug.Log("you just clicked me");
        var newItem = Instantiate(btnInventory);
        var itemTxt = btnInventory.GetComponentInChildren<Text>();
        itemTxt.text = "item " + count;

        newItem.transform.parent = panelInventory;
    }


}
