using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
	// Start is called before the first frame update
	void Start() {
		if (GameManager.instance != null)
			Destroy(GameManager.instance.gameObject);
	}


}
