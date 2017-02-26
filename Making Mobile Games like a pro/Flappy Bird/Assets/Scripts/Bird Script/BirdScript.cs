﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BirdScript : MonoBehaviour {

	public static BirdScript instance;
	[SerializeField]
	private Rigidbody2D myRigidBody;
	[SerializeField]
	private Animator anim;

	private float forwardSpeed = 3f;
	private float bounceSpeed = 4f;

	private bool didFlap;
	public bool isAlive;

	private Button flapButton;

	void Awake() {
//		myRigidBody = GetComponent<Rigidbody2D> (); // less efficient assigning of physics
		if (instance == null) {
			instance = this;
		}
		isAlive = true;

		flapButton = GameObject.FindGameObjectWithTag ("FlapButton").GetComponent<Button> ();
		flapButton.onClick.AddListener (() => {
			FlapTheBird();
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
				transform.rotation = Quaternion.Euler (0, 0, 0);
			} else {
				float angle = 0;
				angle = Mathf.Lerp (0,-90,-myRigidBody.velocity.y / 7);
				transform.rotation = Quaternion.Euler (0,0,angle);
			}
		}
	}

	void SetCamerasX() {
		CameraScript.offsetX = (Camera.main.transform.position.x - transform.position.x) - 1f;
	}

	public float GetPositionX() {
		return transform.position.x;
	}

	public void FlapTheBird() {
		didFlap = true;
	}





}