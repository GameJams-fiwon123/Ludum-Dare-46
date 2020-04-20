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


	// Start is called before the first frame update
	void Start() {
		sprRenderer = GetComponent<SpriteRenderer>();
		if (GameManager.instance.completedDesert) {
			sprRenderer.sprite = nextBackground;
			Destroy(holeObject);
			desertNpc.transform.position = newPosition.position;
		}
	}
}
