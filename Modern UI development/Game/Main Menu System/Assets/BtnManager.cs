using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BtnManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Button[] btns = GetComponentsInChildren <Button>();
		foreach(Button btn in btns) {
			btn.onClick.AddListener (delegate() {
				Debug.Log("clicked!");
			});

		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
