using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn;
using Yarn.Unity;
using Yarn.Unity.Example;

public class Car : MonoBehaviour
{
	bool canInteract = false;

	private void Update() {
		if (Input.GetKeyDown(KeyCode.Z) && canInteract && !GameManager.instance.completedAll) {
			if (Player.instance.HasNote()) {

				VariableStorage varStore = FindObjectOfType<DialogueRunner>().GetComponent<VariableStorage>();
				varStore.SetValue("$completedFutureGuy", true);
				GameManager.instance.completedFutureGuy = true;

				Player.instance.DestroyNote();
				FindObjectOfType<Grass1Background>().ByeCar();
				FindObjectOfType<DialogueRunner>().StartDialogue(GetComponent<NPC>().talkToNode);

			} else if (!GameManager.instance.isDialogue && !GameManager.instance.completedAll) {
				FindObjectOfType<DialogueRunner>().StartDialogue(GetComponent<NPC>().talkToNode);
			}
		}
	}

	private void OnTriggerStay2D(Collider2D collision) {
		if (collision.tag == "Player") {
			canInteract = true;
		}
	}

	private void OnTriggerExit2D(Collider2D collision) {
		if (collision.tag == "Player") {
			canInteract = false;
		}
	}

	public void StopCar() {
		FindObjectOfType<Grass1Background>().StopCar();
	}

	public void FinishedCar() {
		FindObjectOfType<Grass1Background>().DestoryCar();
	}

}
