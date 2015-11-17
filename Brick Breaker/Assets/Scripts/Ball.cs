﻿using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

	public float ballVertSpeed = 10f;

	private Paddle paddle;
	private Vector3 paddleToBallVector;
	private bool hasStarted = false;
	// Use this for initialization
	void Start () {
		paddle = GameObject.FindObjectOfType<Paddle>();
		paddleToBallVector = this.transform.position - paddle.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if (!hasStarted) {
			this.transform.position = paddle.transform.position + paddleToBallVector;
			if (Input.GetMouseButtonDown (0)) {
				hasStarted = true;
				this.rigidbody2D.velocity = new Vector2(1f, ballVertSpeed);
			}
		}
	}
	void OnCollisionEnter2D (Collision2D collision) {
		Vector2 bounceTweak = new Vector2 (Random.Range (0f, 0.2f), Random.Range (0f, 0.2f));
		if (hasStarted) {
			audio.Play ();
			rigidbody2D.velocity += bounceTweak;
		}
	}
}
