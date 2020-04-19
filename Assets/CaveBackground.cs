using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn;
using Yarn.Unity;
using Yarn.Unity.Example;

public class CaveBackground : MonoBehaviour
{

	bool canInteract = false;

	Animator anim;
	public GameObject roncoObject;

	private void Start() {

		anim = GetComponent<Animator>();

		if (GameManager.instance.completedCave) {
			anim.Play("Finished");
			SleepPacMan();
		}
	}

	public void VerifyPlayer() {
		if (Player.instance.HasNote()) {
			GameManager.instance.completedCave = true;
			Player.instance.DestroyNote();


			VariableStorage varStore = FindObjectOfType<DialogueRunner>().GetComponent<VariableStorage>();
			varStore.SetValue("$completedCave", true);
		}
	}

	public void ChangeBackground() {
		if (GameManager.instance.completedCave) {
			anim.Play("Start");
		}

	}

	public void NhacPacMan() {
		FMODUnity.RuntimeManager.PlayOneShot("event:/SFX/Nhac Pac Man");
	}

	public void SleepPacMan() {
		roncoObject.SetActive(true);
	}
}
