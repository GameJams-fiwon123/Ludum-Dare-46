using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesertBackground : MonoBehaviour
{

	public Sprite nextBackground;
	public GameObject holeObject;

	public GameObject desertNpc;
	public Transform newPosition;

	SpriteRenderer sprRenderer;

	bool isCompleted = false;

	// Start is called before the first frame update
	void Start() {
		sprRenderer = GetComponent<SpriteRenderer>();
	}

	private void Update() {
		if (GameManager.instance.completedDesert && !isCompleted) {
			sprRenderer.sprite = nextBackground;
			Destroy(holeObject);
			desertNpc.transform.position = newPosition.position;
			isCompleted = true;
		}
	}
}
