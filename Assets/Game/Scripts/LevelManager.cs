using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
	public void LoadMainMenu() {
		SceneManager.LoadScene("MainMenu");
	}

	public void LoadHouse1() {
		SceneManager.LoadScene("House1");
	}

	public void LoadHouse2() {
		SceneManager.LoadScene("House2");
	}

	public void LoadHouse3() {
		SceneManager.LoadScene("House3");
	}

	public void LoadHouse4() {
		SceneManager.LoadScene("House4");
	}

	public void LoadCity() {
		SceneManager.LoadScene("City");
	}

	public void LoadForest() {
		SceneManager.LoadScene("Forest");
	}

	public void LoadGrass1() {
		SceneManager.LoadScene("Grass1");
	}

	public void LoadGrass2() {
		SceneManager.LoadScene("Grass2");
	}

	public void LoadDesert() {
		SceneManager.LoadScene("Desert");
	}

	public void LoadIce() {
		SceneManager.LoadScene("Ice");
	}

	public void LoadTowerFloor1() {
		SceneManager.LoadScene("TowerFloor1");
	}

	public void LoadTowerFloor2() {
		SceneManager.LoadScene("TowerFloor2");
	}
}
