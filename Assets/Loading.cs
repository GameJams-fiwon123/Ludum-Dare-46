using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Loading : MonoBehaviour
{
	private void Update() {
		if (FMODUnity.RuntimeManager.HasBankLoaded("Master_Bank")) {
			Debug.Log("Master Bank Loaded");
			SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
		}
	}
}
