using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	public static GameController instance;

	private const string HIGH_SCORE = "High Score";
	private const string SELECTED_BIRD = "Selected Bird";
	private const string GREEN_BIRD = "Green Bird";
	private const string RED_BIRD = "Red Bird";

	void Awake() {
		Debug.Log ("Game controller awaken!");
//		PlayerPrefs.DeleteAll ();
		IsTheGameStartedForTheFirstTime ();
		MakeSingleton ();
	}

	/// <summary>
	/// To understand this concept further, kindly use Test Scene 1 & 2 for demonstration
	/// </summary>
	void MakeSingleton() {
		
		if (instance != null) {
			Destroy (gameObject); //we destroy the gamecontroller which is basically a copy when navigating through different scenes
		} else {
			instance = this;
			DontDestroyOnLoad (gameObject);
		}
	}

	void IsTheGameStartedForTheFirstTime() {
		if (!PlayerPrefs.HasKey("IsTheGameStartedForTheFirstTime")) {
			PlayerPrefs.SetInt (HIGH_SCORE,0);
			PlayerPrefs.SetInt (SELECTED_BIRD,0);
			PlayerPrefs.SetInt (GREEN_BIRD,1);
			PlayerPrefs.SetInt (RED_BIRD,1);
			PlayerPrefs.SetInt ("IsTheGameStartedForTheFirstTime",0);
		}
	}

	public void SetHighscore(int score) {
		PlayerPrefs.SetInt (HIGH_SCORE, score);
	}

	public int GetHighscore() {
		return PlayerPrefs.GetInt (HIGH_SCORE);
	}

	public void SetSelectedBird(int selectedBird) {
		PlayerPrefs.SetInt (SELECTED_BIRD, selectedBird);
	}

	public int GetSelectedBird() {
		return PlayerPrefs.GetInt (SELECTED_BIRD);
	}

	public void UnlockGreenBird() {
		PlayerPrefs.SetInt (GREEN_BIRD, 1);
	}

	public int IsGreenBirdUnlocked() {
		return PlayerPrefs.GetInt (GREEN_BIRD);
	}

	public void UnlockRedBird() {
		PlayerPrefs.SetInt (RED_BIRD, 1);
	}

	public int IsRedBirdUnlocked() {
		return PlayerPrefs.GetInt (RED_BIRD);
	}
}