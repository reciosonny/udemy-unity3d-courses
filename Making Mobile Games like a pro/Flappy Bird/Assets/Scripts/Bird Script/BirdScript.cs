using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BirdScript : MonoBehaviour {

	public static BirdScript instance;
	[SerializeField]
	private Rigidbody2D myRigidBody;
	[SerializeField]
	private Animator anim;

	[SerializeField]
	private float forwardSpeed = 7f;
	[SerializeField]
	private float bounceSpeed = 4f;

	[SerializeField]
	private AudioClip flyAudioClip;
	[SerializeField]
	private AudioClip deadAudioClip;
	[SerializeField]
	private AudioClip pingAudioClip;

	private float playerScore=0f;
	[SerializeField]
	private Text txtPlayerScore;

	private bool didFlap;
	public bool isAlive;

	private Button flapButton;
	private AudioSource audioSource;

	void Awake() {
//		myRigidBody = GetComponent<Rigidbody2D> (); // less efficient assigning of physics
		if (instance == null) {
			instance = this;
		}
		isAlive = true;
		audioSource = GetComponent<AudioSource> ();

		flapButton = GameObject.FindGameObjectWithTag ("FlapButton").GetComponent<Button> ();
		flapButton.onClick.AddListener (() => {
			if (this.isAlive) {
				FlapTheBird();
				audioSource.clip = flyAudioClip;
				audioSource.Play();
			}
		});

		SetCamerasX ();
	}

	// Use this for initialization
	void Start () {
		
	}

	void FixedUpdate () {
		if (isAlive) {
			Vector3 temp = transform.position;
			temp.x += forwardSpeed * Time.deltaTime;
			transform.position = temp;

			if (didFlap) {
				didFlap = false;
				myRigidBody.velocity = new Vector2 (0, bounceSpeed);
				anim.SetTrigger ("Flap");
			}

			if (myRigidBody.velocity.y >= 0) {

//				transform.rotation = Quaternion.Euler (0, 0, 0);
			} else {
				
				//todo: implementation for turning the bird downward if velocity is less than or equal to 0
				float angle = 0;
				angle = Mathf.Lerp (0, -90, -myRigidBody.velocity.y / 7);
				transform.rotation = Quaternion.Euler (0, 0, angle);
			}
		}
	}

	void SetCamerasX() {
		CameraScript.offsetX = (Camera.main.transform.position.x - transform.position.x) - 1f;
	}

	void OnTriggerEnter2D(Collider2D target) {
		Debug.Log (target.tag);

		if (target.tag == "PipeHolder") {
			Debug.Log ("triggered pipeholder");
			audioSource.clip = pingAudioClip;
			audioSource.Play ();

			playerScore += 1;
			txtPlayerScore.text = playerScore.ToString();
		}

	}

	void OnCollisionEnter2D(Collision2D target) {

		Debug.Log ("Collided");
		if (target.gameObject.tag == "Pipe" || target.gameObject.tag == "Ground") {
			if (this.isAlive) {
				audioSource.clip = deadAudioClip;
				this.isAlive = false;
				anim.SetTrigger ("Bird Died");
				audioSource.Play ();
			}
		} 

	}


	public float GetPositionX() {
		return transform.position.x;
	}

	public void FlapTheBird() {
		didFlap = true;
	}





}