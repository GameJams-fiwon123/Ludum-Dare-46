using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
	public TeleportManager.placesName nextPlace;
	public bool exactPosition = true;
	public bool isX, isY;
	public bool isInverted = false;
	public bool isChangeValue = false;

	private void OnTriggerEnter2D(Collider2D collision) {
		float xValue, yValue;

		if (isInverted && !isChangeValue) {
			xValue = (isX && !exactPosition) | exactPosition ? -1f : Player.instance.gameObject.transform.position.y;
			yValue = (isY && !exactPosition) | exactPosition ? -1f : Player.instance.gameObject.transform.position.x;

		} else if (isInverted && isChangeValue) {
			xValue = (isX && !exactPosition) | exactPosition ? -1f : -Player.instance.gameObject.transform.position.y;
			yValue = (isY && !exactPosition) | exactPosition ? -1f : -Player.instance.gameObject.transform.position.x;
		}
		else {
			xValue = (isX && !exactPosition) | exactPosition ? -1f : Player.instance.gameObject.transform.position.x;
			yValue = (isY && !exactPosition) | exactPosition ? -1f : Player.instance.gameObject.transform.position.y;
		}

		FindObjectOfType<TeleportManager>().TeleportTo(nextPlace, xValue, yValue);
	}
}
