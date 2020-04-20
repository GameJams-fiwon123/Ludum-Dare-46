using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PostOfficeBackground : MonoBehaviour
{
	public Sprite nextBackground;
	public GameObject[] arrayObjects;

	SpriteRenderer sprRenderer;


	// Start is called before the first frame update
	void Start() {
		sprRenderer = GetComponent<SpriteRenderer>();
		if (GameManager.instance.completedPostOffice) {
			sprRenderer.sprite = nextBackground;
			foreach (GameObject obj in arrayObjects) {
				Destroy(obj);
			}			

		}
	}
}
