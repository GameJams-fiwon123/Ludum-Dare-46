using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn;
using Yarn.Unity;
using Yarn.Unity.Example;

public class Box : MonoBehaviour
{
	bool canInteract = false;
	public Sprite nextSprite;

	public BoxCollider2D boxCol;

	SpriteRenderer sprRenderer;

	private void Start() {
		sprRenderer = GetComponent<SpriteRenderer>();
	}

	private void Update() {
		if (Input.GetKeyDown(KeyCode.Z) && canInteract && !GameManager.instance.isDialogue) {
			if (Player.instance.HasNote()) {
				GameManager.instance.completedPostOffice = true;
				Player.instance.DestroyNote();
				sprRenderer.sprite = nextSprite;
				boxCol.size = new Vector2(0.6366018f, 0.6470239f);
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
