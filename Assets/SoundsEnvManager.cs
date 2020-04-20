using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundsEnvManager : MonoBehaviour
{
	// Start is called before the first frame update
	void Awake() {
		if (FindObjectsOfType<SoundsEnvManager>().Length > 1) {
			Destroy(gameObject);
		} else {
			DontDestroyOnLoad(gameObject);
		}
	}

}
