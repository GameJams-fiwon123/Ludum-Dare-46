using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

	public float speed = 100f;

	Rigidbody2D rbd2D;
	SpriteRenderer sprRenderer;
	Vector2 motion = Vector2.zero;

	Animator anim;

	public static Player instance;

	private void Awake() {
		if (FindObjectsOfType<Player>().Length > 1) {
			Destroy(gameObject);
		} else {
			DontDestroyOnLoad(gameObject);
			instance = this;
		}
	}

	// Start is called before the first frame update
	void Start() {
		rbd2D = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
		sprRenderer = GetComponent<SpriteRenderer>();
	}

	// Update is called once per frame
	void Update() {
		InputMovement();
		InputInteraction();
		Animation();
	}

	private void InputInteraction() {

	}

	private void Animation() {
		if (motion.x != 0 || motion.y != 0) {
			anim.SetBool("isWalking", true);
			sprRenderer.flipX = motion.x == 1f ? false : true;
		} else {
			anim.SetBool("isWalking", false);
		}

		anim.SetInteger("horizontal", (int)motion.x);
		anim.SetInteger("vertical", (int)motion.y);
	}

	private void InputMovement() {
		motion.x = Input.GetAxisRaw("Horizontal");
		motion.y = Input.GetAxisRaw("Vertical");
	}

	// Physic
	void FixedUpdate() {
		Movement();
	}

	private void Movement() {
		rbd2D.velocity = motion.normalized * speed * Time.fixedDeltaTime;
	}

	public void SetPosition(Vector3 newPosition) {
		transform.position = newPosition;
	}
}
