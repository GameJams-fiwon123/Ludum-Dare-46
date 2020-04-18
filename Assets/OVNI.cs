using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OVNI : MonoBehaviour
{

	public Sprite nextSprite;

	Animator anim;

	private void Start() {
		if (GameManager.instance.completedForest) {
			Destroy(gameObject);
		} else {
			anim = GetComponent<Animator>();
		}
	}

	public void VerifyPlayer() {
		if (Player.instance.HasNote()) {
			GameManager.instance.completedForest = true;
			Player.instance.DestroyNote();
		}
	}

	public void GoBackHome() {
		if (GameManager.instance.completedForest) {
			anim.Play("Start");
		}

	}
}
