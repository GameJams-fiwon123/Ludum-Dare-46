using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
	public TeleportManager.placesName nextPlace;
	public bool exactPosition = true;
	public bool isX, isY;

	private void OnTriggerEnter2D(Collider2D collision) {
		float xValue = (isX && !exactPosition) | exactPosition ? -1f : Player.instance.gameObject.transform.position.x;
		float yValue = (isY && !exactPosition) | exactPosition ? -1f : Player.instance.gameObject.transform.position.y;
		FindObjectOfType<TeleportManager>().TeleportTo(nextPlace, xValue, yValue);
	}
}
