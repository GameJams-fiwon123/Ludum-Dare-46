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
		if (Player.instance.HasNote() && !GameManager.instance.completedCave) {
			GameManager.instance.completedCave = true;
			Player.instance.DestroyNote();


			VariableStorage varStore = FindObjectOfType<DialogueRunner>().GetComponent<VariableStorage>();
			varStore.SetValue("$completedCave", true);

			FMODUnity.RuntimeManager.PlayOneShot("event:/SFX/Nhac Pac Man");
		}
	}

	public void ChangeBackground() {
		VariableStorage varStore = FindObjectOfType<DialogueRunner>().GetComponent<VariableStorage>();

		if (GameManager.instance.completedCave && varStore.GetValue("$isFirstCave").AsBool) {
			anim.Play("Start");
			varStore.SetValue("$isFirstCave", false);
		}

	}

	public void SleepPacMan() {
		roncoObject.SetActive(true);
	}
}
