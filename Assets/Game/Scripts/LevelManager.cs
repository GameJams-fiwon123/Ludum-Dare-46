using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
	IEnumerator LoadScene(string currentScene, string nextScene) {
		yield return new WaitForSeconds(0.01f);
		SceneManager.LoadScene(nextScene, LoadSceneMode.Additive);
		yield return new WaitForSeconds(0.01f);
		SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());
	}

	public void Clique() {
		FMODUnity.RuntimeManager.PlayOneShot("event:/SFX/Clique");
	}

	public void LoadDoctor() {
		Destroy(FindObjectOfType<TitleMusic>().gameObject);
		Clique();
		SceneManager.LoadScene("Doctor");
	}

	public void LoadMainMenu() {
		Clique();
		SceneManager.LoadScene("MainMenu");
	}

	public void LoadCredtis() {
		Clique();
		SceneManager.LoadScene("Credits");
	}

	public void LoadTutorial() {
		Clique();
		SceneManager.LoadScene("Tutorial");
	}

	public void ExitGame() {
		Clique();
		Application.Quit();
	}

	public void LoadHouse1Normal() {
		SceneManager.LoadScene("House1");
	}

	public void LoadHouse1() {
		StartCoroutine(LoadScene(SceneManager.GetActiveScene().name, "House1"));
	}

	public void LoadHouse2() {
		StartCoroutine(LoadScene(SceneManager.GetActiveScene().name, "House2"));
	}

	public void LoadHouse3() {
		StartCoroutine(LoadScene(SceneManager.GetActiveScene().name, "House3"));
	}

	public void LoadPostOffice() {
		StartCoroutine(LoadScene(SceneManager.GetActiveScene().name, "PostOffice"));
	}

	public void LoadCity() {
		StartCoroutine(LoadScene(SceneManager.GetActiveScene().name, "City"));
	}

	public void LoadForest() {
		StartCoroutine(LoadScene(SceneManager.GetActiveScene().name, "Forest"));
	}

	public void LoadGrass1() {
		StartCoroutine(LoadScene(SceneManager.GetActiveScene().name, "Grass1"));
	}

	public void LoadGrass2() {
		StartCoroutine(LoadScene(SceneManager.GetActiveScene().name, "Grass2"));
	}

	public void LoadDesert() {
		StartCoroutine(LoadScene(SceneManager.GetActiveScene().name, "Desert"));
	}

	public void LoadIce() {
		StartCoroutine(LoadScene(SceneManager.GetActiveScene().name, "Ice"));
	}

	public void LoadTowerFloor1() {
		StartCoroutine(LoadScene(SceneManager.GetActiveScene().name, "TowerFloor1"));
	}

	public void LoadTowerFloor2() {
		StartCoroutine(LoadScene(SceneManager.GetActiveScene().name, "TowerFloor2"));
	}

	public void LoadCave() {
		StartCoroutine(LoadScene(SceneManager.GetActiveScene().name, "Cave"));
	}
}
