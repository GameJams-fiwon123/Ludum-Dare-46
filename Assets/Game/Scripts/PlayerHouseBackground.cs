using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHouseBackground : MonoBehaviour
{
	public Animator anim;

	public void FinishGame() {
		if (GameManager.instance.completedAll) {
			anim.Play("Start");
			FMODUnity.RuntimeManager.PlayOneShot("event:/SFX/Shhh (Thanks for Playing)");
		}
	}

	public void BeginGame() {
		anim.Play("Begin");
	}

	public void GoBackMainMenu() {
		Destroy(Player.instance.gameObject);
		if (FindObjectOfType<AudioManager>())
			Destroy(FindObjectOfType<AudioManager>().gameObject);
		if (FindObjectOfType<NotesManager>())
			Destroy(FindObjectOfType<NotesManager>().gameObject);
		if (FindObjectOfType<SoundsEnvManager>())
			Destroy(FindObjectOfType<SoundsEnvManager>().gameObject);

		FindObjectOfType<LevelManager>().LoadMainMenu();
	}

}
