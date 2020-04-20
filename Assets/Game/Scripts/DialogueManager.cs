using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Yarn.Unity;

public class DialogueManager : MonoBehaviour
{
	FMOD.Studio.EventInstance sfxLetterAudio;

	float timePassed;
	float timeMax = 0.1f;

	public Color enableColor;
	public Color disableColor;

	public Button[] options;
	private int indexOptions;
	private int countActives;

	bool isOptions = false;

	public void Start() {
		sfxLetterAudio = FMODUnity.RuntimeManager.CreateInstance("event:/SFX/Letras - diálogo");
	}

	public void Update() {
		if (timePassed >= timeMax)
			timePassed = timeMax;
		else
			timePassed += Time.deltaTime;

		if (Input.GetKeyDown(KeyCode.Z) && GameManager.instance.isDialogue && !isOptions && timePassed >= timeMax) {
			FindObjectOfType<DialogueUI>().MarkLineComplete();
		} else if (Input.GetKeyDown(KeyCode.Z) && isOptions && timePassed >= timeMax) {
			options[indexOptions].onClick.Invoke();
		}

		if (Input.GetKeyDown(KeyCode.UpArrow) && isOptions && timePassed >= timeMax) {
			options[indexOptions].transform.GetChild(0).GetComponent<Text>().color = disableColor;
			indexOptions--;
			if (indexOptions < 0) {
				indexOptions = 0;
			}

			options[indexOptions].transform.GetChild(0).GetComponent<Text>().color = enableColor;

		} else if (Input.GetKeyDown(KeyCode.DownArrow) && isOptions && timePassed >= timeMax) {
			options[indexOptions].transform.GetChild(0).GetComponent<Text>().color = disableColor;
			indexOptions++;
			if (indexOptions > countActives-1) {
				indexOptions = countActives-1;
			}

			options[indexOptions].transform.GetChild(0).GetComponent<Text>().color = enableColor;
		}
	}

	public void StartAudio() {
		sfxLetterAudio.start();
	}

	public void StopAudio() {
		sfxLetterAudio.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
	}

	public void StartDialogue() {
		GameManager.instance.isDialogue = true;
		timePassed = 0f;
	}

	public void StopDialogue() {
		GameManager.instance.isDialogue = false;
	}

	public void OnDestroy() {
		sfxLetterAudio.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
	}

	public void OptionsStop() {
		isOptions = false;
	}

	public void OptionsStart() {
		indexOptions = 0;
		countActives = 0;

		foreach (Button btn in options) {
			if (btn.gameObject.activeSelf) {
				options[countActives].transform.GetChild(0).GetComponent<Text>().color = disableColor;
				countActives++;
			}
		}

		options[indexOptions].transform.GetChild(0).GetComponent<Text>().color = enableColor;

		timePassed = 0f;
		isOptions = true;
	}
}
