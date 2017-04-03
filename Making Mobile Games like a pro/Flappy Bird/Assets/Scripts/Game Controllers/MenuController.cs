using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour {

	public static MenuController instance;

	[SerializeField]
	private GameObject[] birds;
	
	private bool isGreenBirdUnlocked, isRedBirdUnlocked;

	void Awake() {
		MakeInstance ();
	}

	void Start() {
		birds [GameController.instance.GetSelectedBird ()].SetActive (true);
		CheckIfBirdsAreUnlocked ();
	}

	void MakeInstance() {
		if (instance == null) {
			instance = this;
		}
	}

	void CheckIfBirdsAreUnlocked() {
		isRedBirdUnlocked = GameController.instance.IsRedBirdUnlocked () == 1;
		isGreenBirdUnlocked = GameController.instance.IsGreenBirdUnlocked () == 1;
	}

	public void ChangeBird() {
		int birdSelected = GameController.instance.GetSelectedBird ();
		Debug.Log (birdSelected);

		switch (birdSelected) {
		case 0:
			Debug.Log (isGreenBirdUnlocked);
			if (isGreenBirdUnlocked) {
				birds [0].SetActive (false);
				GameController.instance.SetSelectedBird (1);
				birds [GameController.instance.GetSelectedBird ()].SetActive (true);
			}

			break;
		case 1:
			if (isRedBirdUnlocked) {
				birds [1].SetActive (false);
				GameController.instance.SetSelectedBird (2);
				birds [GameController.instance.GetSelectedBird ()].SetActive (true);
			} else {
				birds [1].SetActive (false);
				GameController.instance.SetSelectedBird (0);
				birds [GameController.instance.GetSelectedBird ()].SetActive (true);
			}

			break;
		case 2: 
			birds [2].SetActive (false);
			GameController.instance.SetSelectedBird (0);
			birds [GameController.instance.GetSelectedBird ()].SetActive (true);

			break;
		}
	}



}