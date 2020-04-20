using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Yarn;
using Yarn.Unity;

public class GameManager : MonoBehaviour
{

	public VariableStorage variableStorage;

	public TeleportManager.placesName currentPlace { get; private set; } = TeleportManager.placesName.None;

	public Vector3 nextPositionPlayer { get; private set; } = Vector3.zero;

	public static GameManager instance;

	public bool completedDesert = false;
	public bool completedIce = false;
	public bool completedHomeless = false;
	public bool completedCave = false;
	public bool completedForest = false;
	public bool completedPostOffice = false;
	public bool completedFutureGuy = false;
	public bool completedAll = false;

	public bool spawnCar = false;

	public bool gameStarted = false;
	public bool isFinished = false;


	// Start is called before the first frame update
	void Awake() {
		if (FindObjectsOfType<GameManager>().Length > 1) {
			Destroy(gameObject);
		} else {
			DontDestroyOnLoad(gameObject);
			instance = this;
		}
	}

	private void Start() {
		SceneManager.sceneLoaded += OnSceneLoaded;
	}

	public void OnSceneLoaded(Scene scene, LoadSceneMode mode) {
		StartCoroutine(VerifyDialogues());
	}

	IEnumerator VerifyDialogues() {
		yield return new WaitForSeconds(0.05f);

		if (FindObjectOfType<DialogueRunner>()) {
			variableStorage = FindObjectOfType<DialogueRunner>().GetComponent<VariableStorage>();

			variableStorage.SetValue("$forestNote", completedForest);
			variableStorage.SetValue("$iceNote", completedIce);
			variableStorage.SetValue("$completedHomeless", completedHomeless);
			if (completedHomeless)
				variableStorage.SetValue("$isFirstTime", false);

			variableStorage.SetValue("$desertNote", completedDesert);
			variableStorage.SetValue("$completedCave", completedCave);
			variableStorage.SetValue("$completedFutureGuy", completedFutureGuy);
			variableStorage.SetValue("$completedAll", completedAll);
			variableStorage.SetValue("$completedPostOffice", completedPostOffice);
		}
	}

	public void SetPlace(TeleportManager.placesName nextPlace) {
		currentPlace = nextPlace;
	}

	public void SavePlayerPosition(float xValue, float yValue) {
		nextPositionPlayer = new Vector3(xValue, yValue, 0f);
	}

	public void StartGame() {
		gameStarted = true;
	}

}
