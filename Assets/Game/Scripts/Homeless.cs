using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn;
using Yarn.Unity;

public class Homeless : MonoBehaviour
{

	[YarnCommand("verifyPlayer")]
	public void VerifyPlayer() {
		if (Player.instance.HasNote() && !GameManager.instance.completedHomeless) {
			GameManager.instance.completedHomeless = true;
			Player.instance.DestroyNote();

			VariableStorage varStore = FindObjectOfType<DialogueRunner>().GetComponent<VariableStorage>();

			varStore.SetValue("$completedHomeless", true);
			varStore.SetValue("$answer", true);
		} else {
			if (GameManager.instance.completedHomeless && Player.instance.HasNote()) {

				VariableStorage varStore = FindObjectOfType<DialogueRunner>().GetComponent<VariableStorage>();
				varStore.SetValue("$answer", true);
			} else {
				VariableStorage varStore = FindObjectOfType<DialogueRunner>().GetComponent<VariableStorage>();
				varStore.SetValue("$answer", false);
			}
		}
	}
}
