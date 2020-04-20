using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceBackground : MonoBehaviour
{
	public Sprite nextBackground;
	public GameObject lakeObject;

	SpriteRenderer sprRenderer;


	// Start is called before the first frame update
	void Start() {
		sprRenderer = GetComponent<SpriteRenderer>();
		if (GameManager.instance.completedIce) {
			sprRenderer.sprite = nextBackground;
			Destroy(lakeObject);
		}
	}
}
