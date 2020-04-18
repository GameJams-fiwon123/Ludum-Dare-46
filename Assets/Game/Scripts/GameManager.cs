using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	public TeleportManager.placesName currentPlace { get; private set; } = TeleportManager.placesName.None;

	public Vector3 nextPositionPlayer { get; private set; } = Vector3.zero;

	public static GameManager instance;

	public bool completedDesert = false;
	public bool completedIce = false;
	public bool completedGrass1 = false;
	public bool completedCave = false;
	public bool completedForest = false;


	// Start is called before the first frame update
	void Awake() {
		if (FindObjectsOfType<GameManager>().Length > 1) {
			Destroy(gameObject);
		} else {
			DontDestroyOnLoad(gameObject);
			instance = this;
		}
	}

	public void SetPlace(TeleportManager.placesName nextPlace) {
		currentPlace = nextPlace;
	}

	public void SavePlayerPosition(float xValue, float yValue) {
		nextPositionPlayer = new Vector3(xValue, yValue, 0f);
	}

}
