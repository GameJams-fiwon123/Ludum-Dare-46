using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
	public void StopCar() {
		FindObjectOfType<Grass1Background>().StopCar();
	}

	public void FinishedCar() {
		FindObjectOfType<Grass1Background>().DestoryCar();
	}
}
