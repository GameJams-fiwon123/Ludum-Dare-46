using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{
	public TeleportManager.placesName placeName;
	public bool isPlayer = false;

	private void Update() {
		float d = Vector2.Distance(transform.position, Player.instance.transform.position);
		d = (20f - d) / 20f;
		d = Mathf.Clamp(d, 0.8f, 1);

		FindObjectOfType<AudioManager>().audioGameplay.SetParameter(gameObject.name, d);
	}

	private void OnDestroy() {
		Debug.Log(gameObject.name);
		FindObjectOfType<AudioManager>().audioGameplay.SetParameter(gameObject.name, 0f);
	}
}
