using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
	FMOD.Studio.EventInstance sfxLetterAudio;

	public void Start() {
		sfxLetterAudio = FMODUnity.RuntimeManager.CreateInstance("event:/SFX/Letras - diálogo");
	}

	public void StartAudio() {

		sfxLetterAudio.start();
	}

	public void StopAudio() {
		sfxLetterAudio.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
	}

	public void OnDestroy() {
		sfxLetterAudio.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
	}
}
