using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameplayController : MonoBehaviour {

	public static GameplayController instance;

	[SerializeField]
	private Text scoreText, endScore, bestScore, gameOverText;

	[SerializeField]
	private Button restartGameButton, instructionsButton;

	[SerializeField]
	private GameObject pausePanel;

	[SerializeField]
	private GameObject[] birds;

	[SerializeField]
	private Sprite[] medals;

	[SerializeField]
	private Image medalImage;

	public void PauseGame() {
		if (BirdScript.instance != null) {
			if (BirdScript.instance.isAlive) {
				pausePanel.SetActive (true);
				gameOverText.gameObject.SetActive (false);
				endScore.text = BirdScript.instance.playerScore.ToString();
				bestScore.text = GameController.instance.GetHighscore ().ToString();
				Time.timeScale = 0f; //pauses animations and frames(literally pauses everything.). If set to 1f, it resumes

				restartGameButton.onClick.RemoveAllListeners ();
				restartGameButton.onClick.AddListener (() => ResumeGame());
			}
		}
	}

	public void GoToMenuButton() {
		SceneFader.instance.FadeIn ("MainMenu");
	}

	public void ResumeGame () {
		pausePanel.SetActive (false);
		Time.timeScale = 1f;
	}

	public void RestartGame() {
		SceneFader.instance.FadeIn (Application.loadedLevelName);
	}

	public void PlayGame() {
		scoreText.gameObject.SetActive (true);
		birds [GameController.instance.GetSelectedBird ()].SetActive (true);
		instructionsButton.gameObject.SetActive (true);
		Time.timeScale = 1f;
	}

	public void SetScore(int score) {
		scoreText.text = score.ToString ();
	}

	public void PlayerDiedShowScore(int score) {
		pausePanel.SetActive (true);
		gameOverText.gameObject.SetActive (false);
		scoreText.gameObject.SetActive (false);

		endScore.text = score.ToString ();

		if (score > GameController.instance.GetHighscore()) {
			GameController.instance.SetHighscore (score);
		}

		bestScore.text = GameController.instance.GetHighscore ().ToString();

		if (score <= 20) {
			medalImage.sprite = medals [0];
		} else if (score > 20 && score < 40) {
			medalImage.sprite = medals [1];

			if (GameController.instance.IsGreenBirdUnlocked() == 0) {
				GameController.instance.UnlockGreenBird ();
			}
		} else {

			medalImage.sprite = medals [2];

			if (GameController.instance.IsRedBirdUnlocked() == 0) {
				GameController.instance.UnlockRedBird ();
			}

		}


		restartGameButton.onClick.RemoveAllListeners ();
		restartGameButton.onClick.AddListener (() => RestartGame());
	}



	void Awake() {
		MakeInstance ();
		pausePanel.SetActive (false);

//		Time.timeScale = 0f;
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void MakeInstance() {
		if (instance == null) {
			instance = this;
		}
	}
}
