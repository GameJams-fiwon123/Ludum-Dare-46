using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoctorBackground : MonoBehaviour
{
	public Animator anim;

	public void FinishedDialogue() {
		anim.Play("Start");
	}

	public void ChangeScene() {
		FindObjectOfType<LevelManager>().LoadHouse1Normal();
	}
}
