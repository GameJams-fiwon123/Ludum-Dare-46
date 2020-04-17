using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
	public FMODUnity.StudioEventEmitter audioGameplay;

	private void Awake() {
		if (FindObjectsOfType<AudioManager>().Length > 1) {
			Destroy(gameObject);
		} else {
			DontDestroyOnLoad(gameObject);
		}
	}
}
