using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NotesManager : MonoBehaviour
{
	public Note[] notes;

	private void Awake() {
		if (FindObjectsOfType<NotesManager>().Length > 1) {
			Destroy(gameObject);
		} else {
			DontDestroyOnLoad(gameObject);
		}
	}

	private void Start() {
		SceneManager.sceneLoaded += OnSceneLoaded;
		VerifyNotes();
	}

	public void OnSceneLoaded(Scene scene, LoadSceneMode mode) {
		VerifyNotes();
	}

	public void VerifyNotes() {
		TeleportManager.placesName currentPlace = GameManager.instance.currentPlace;

		foreach (Note note in notes) {
			if (note.placeName == currentPlace) {
				if (!note.isPlayer)
					note.gameObject.SetActive(true);
			} else {
				if (note)
					note.gameObject.SetActive(false);
			}
		}
	}

	private void OnDestroy() {
		SceneManager.sceneLoaded -= OnSceneLoaded;
	}
}
