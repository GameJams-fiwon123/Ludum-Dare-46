using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;
using Yarn.Unity.Example;

public class CaveBackground : MonoBehaviour
{

	bool canInteract = false;

	Animator anim;

	private void Start() {

		anim = GetComponent<Animator>();

		if (GameManager.instance.completedCave) {
			Debug.Log("Alterou");
			anim.Play("Finished");
		}
	}

	public void VerifyPlayer() {
		if (Player.instance.HasNote()) {
			GameManager.instance.completedCave = true;
			Player.instance.DestroyNote();
		}
	}

	public void ChangeBackground() {
		if (GameManager.instance.completedCave) {
			anim.Play("Start");
		}

	}
}
