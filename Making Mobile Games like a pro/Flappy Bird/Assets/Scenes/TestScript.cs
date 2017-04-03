using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TestScript : MonoBehaviour {

	public void GoToScene1() {
		SceneManager.LoadScene ("Test Scene 1");
	}

	public void GoToScene2() {
		SceneManager.LoadScene ("Test Scene 2");
	}

	[SerializeField]
	private Text score;

	// Use this for initialization
	void Start () {
//		var gameController = new GameController ();
//		gameController.SetHighscore (0);
		if (score != null) {
			score.text = GameController.instance.GetHighscore ().ToString ();
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
