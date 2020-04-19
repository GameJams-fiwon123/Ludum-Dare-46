using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class Bed : MonoBehaviour
{

	private void OnTriggerEnter2D(Collider2D collision) {
		if (collision.tag == "Player" && GameManager.instance.completedAll) {
			GameManager.instance.gameStarted = false;
			Player.instance.GoSleep(transform.position);
			GameManager.instance.isFinished = true;
		}
	}
}
