using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NotesManager : MonoBehaviour
{
	public Note[] notes;

	private void Start() {
		if (FindObjectsOfType<NotesManager>().Length > 1) {
			Destroy(gameObject);
		} else {
			DontDestroyOnLoad(gameObject);
			SceneManager.sceneLoaded += OnSceneLoaded;
		}
	}

	public void OnSceneLoaded(Scene scene, LoadSceneMode mode) {
		foreach (Note note in notes) {
			if (note.placeName == FindObjectOfType<TeleportManager>().currentPlace) {
				note.gameObject.SetActive(true);
			} else {
				note.gameObject.SetActive(false);
			}
		}
	}
}
