using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHouseBackground : MonoBehaviour
{
	public Animator anim;

	public void FinishGame() {
		if (GameManager.instance.completedAll) {
			anim.Play("Start");
		}
	}
}
