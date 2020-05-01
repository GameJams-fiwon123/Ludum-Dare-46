using FMOD;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Loading : MonoBehaviour
{
	bool isLoading = false;

	private void Update() {
		if (FMODUnity.RuntimeManager.HasBankLoaded("Master_Bank") && isLoading) {
			SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
		}
	}

	public void Loaded() {
		isLoading = true;
	}
}
