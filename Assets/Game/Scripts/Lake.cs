using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn;
using Yarn.Unity;
using Yarn.Unity.Example;

public class Lake : MonoBehaviour
{
	bool canInteract = false;

	private void Update() {
		if (Input.GetKeyDown(KeyCode.Z) && canInteract) {
			if (Player.instance.HasNote()) {
				GameManager.instance.completedIce = true;
				Player.instance.DestroyNote();
				FMODUnity.RuntimeManager.PlayOneShot("event:/SFX/Splash");
				
	} else {
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
}
