using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn;
using Yarn.Unity;

public class OVNI : MonoBehaviour
{

	Animator anim;
	public Animator alienAnim;

	private void Start() {
		if (GameManager.instance.completedForest) {
			Destroy(gameObject);
		} else {
			anim = GetComponent<Animator>();
		}
	}

	public void VerifyPlayer() {
		if (Player.instance.HasNote() && !GameManager.instance.completedForest && !GameManager.instance.isDialogue) {
			GameManager.instance.completedForest = true;

			VariableStorage varStore = FindObjectOfType<DialogueRunner>().GetComponent<VariableStorage>();
			varStore.SetValue("$forestNote", true);

			Player.instance.DestroyNote();
		}
	}

	public void GoBackHome() {
		if (GameManager.instance.completedForest) {
			FMODUnity.RuntimeManager.PlayOneShot("event:/SFX/GoodByeHuman");
			anim.Play("Start");
			alienAnim.Play("Walking");
		}

	}
}
