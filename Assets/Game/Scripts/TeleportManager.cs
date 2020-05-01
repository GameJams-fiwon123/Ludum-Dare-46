using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportManager : MonoBehaviour
{
	public enum placesName { None ,City, Desert, Forest, Grass1, Grass2, House1, House2,
										House3, PostOffice, Ice, TowerFloor1, TowerFloor2, Cave}

	public placesName currentPlace;

  void Awake() {
		if (GameManager.instance.currentPlace != placesName.None) {
			foreach (Transform t in transform) {
				if (t.GetComponent<Teleport>().nextPlace == GameManager.instance.currentPlace) {
				  Vector3 newPlayerPosition = GameManager.instance.nextPositionPlayer;
					newPlayerPosition.x = newPlayerPosition.x == -1f ? t.position.x : newPlayerPosition.x;
					newPlayerPosition.y = newPlayerPosition.y == -1f ? t.position.y : newPlayerPosition.y;

					Player.instance.SetPosition(newPlayerPosition);

					break;
				}
			}
		}

		GameManager.instance.SetPlace(currentPlace);
	}

	public void TeleportTo(placesName place, float xValue, float yValue) {

		GameManager.instance.SavePlayerPosition(xValue, yValue);

		switch (place) {
			case placesName.City:
				FindObjectOfType<LevelManager>().LoadCity();
				break;
			case placesName.Desert:
				FindObjectOfType<LevelManager>().LoadDesert();
				break;
			case placesName.Forest:
				FindObjectOfType<LevelManager>().LoadForest();
				break;
			case placesName.Grass1:
				FindObjectOfType<LevelManager>().LoadGrass1();
				break;
			case placesName.Grass2:
				FindObjectOfType<LevelManager>().LoadGrass2();
				break;
			case placesName.House1:
				FindObjectOfType<LevelManager>().LoadHouse1();
				break;
			case placesName.House2:
				FindObjectOfType<LevelManager>().LoadHouse2();
				break;
			case placesName.House3:
				FindObjectOfType<LevelManager>().LoadHouse3();
				break;
			case placesName.PostOffice:
				FindObjectOfType<LevelManager>().LoadPostOffice();
				break;
			case placesName.Ice:
				FindObjectOfType<LevelManager>().LoadIce();
				break;
			case placesName.TowerFloor1:
				FindObjectOfType<LevelManager>().LoadTowerFloor1();
				break;
			case placesName.TowerFloor2:
				FindObjectOfType<LevelManager>().LoadTowerFloor2();
				break;
			case placesName.Cave:
				FindObjectOfType<LevelManager>().LoadCave();
				break;
		}
	}
}
