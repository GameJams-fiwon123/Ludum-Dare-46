using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

	public float speed = 100f;

	Rigidbody2D rbd2D;
	Vector2 motion = Vector2.zero;

	// Start is called before the first frame update
	void Start() {
		rbd2D = GetComponent<Rigidbody2D>();
	}

	// Update is called once per frame
	void Update() {
		motion.x = Input.GetAxisRaw("Horizontal");
		motion.y = Input.GetAxisRaw("Vertical");
	}

	void FixedUpdate() {
		Movement();
	}

	private void Movement() {
		rbd2D.velocity = motion * speed * Time.fixedDeltaTime;
	}
}
