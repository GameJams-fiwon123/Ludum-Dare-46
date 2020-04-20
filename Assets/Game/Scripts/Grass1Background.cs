using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn;
using Yarn.Unity;

public class Grass1Background : MonoBehaviour
{
	public GameObject portalPrefab;
	public GameObject portal2Prefab;
	public GameObject carPrefab;
	public GameObject futureGuyNPCPrefab;

	public Transform positionCarStop;

	public Transform transformPortal1;
	public Transform transformPortal2;

	public Transform trasnformFutureGuyNPC;

	GameObject instancePortal1;
	GameObject instancePortal2;
	GameObject instanceCar;
	GameObject instanceFutureGuyNPC;

	// Start is called before the first frame update
	void Start() {

		if (!GameManager.instance.completedAll &&
				GameManager.instance.completedCave &&
				GameManager.instance.completedDesert &&
				GameManager.instance.completedForest &&
				GameManager.instance.completedHomeless &&
				GameManager.instance.completedIce &&
				GameManager.instance.completedPostOffice &&
				!GameManager.instance.spawnCar) {

			GameManager.instance.spawnCar = true;
			StartCoroutine(SpawnPortal());
		} else if (GameManager.instance.spawnCar && !GameManager.instance.completedAll) {
			StartCoroutine(LoadSpawn());
		}
	}


	public void VerifyQuest() {
		if (!GameManager.instance.completedAll &&
				GameManager.instance.completedCave &&
				GameManager.instance.completedDesert &&
				GameManager.instance.completedForest &&
				GameManager.instance.completedHomeless &&
				GameManager.instance.completedIce &&
				GameManager.instance.completedPostOffice &&
				!GameManager.instance.spawnCar) {

			GameManager.instance.spawnCar = true;
			StartCoroutine(SpawnPortal());
		}
	}

	IEnumerator LoadSpawn() {
		yield return new WaitForSeconds(0.05f);
		instanceCar = Instantiate(carPrefab, positionCarStop.position, Quaternion.identity, transform.parent);
		instanceFutureGuyNPC = Instantiate(futureGuyNPCPrefab, trasnformFutureGuyNPC.position, Quaternion.identity, transform.parent);
	}

	IEnumerator SpawnPortal() {
		// Open Portal
		yield return new WaitForSeconds(1f);
		FMODUnity.RuntimeManager.PlayOneShot("event:/SFX/Portal do Tempo");
		yield return new WaitForSeconds(1.25f);
		instancePortal1 = Instantiate(portalPrefab, transformPortal1.position, Quaternion.identity, transform.parent);
		instancePortal1.GetComponent<Animator>().Play("Open");
		StartCoroutine(SpawnCar());
	}

	IEnumerator SpawnCar() {
		GameManager.instance.spawnCar = true;
		// Move Car
		yield return new WaitForSeconds(1f);
		instanceCar = Instantiate(carPrefab, transformPortal1.position, Quaternion.identity, transform.parent);
		instanceCar.GetComponent<Animator>().Play("Start");
		FMODUnity.RuntimeManager.PlayOneShot("event:/SFX/Fusca Chegando");
	}

	public void StopCar() {
		// Spawn NPC
		instanceFutureGuyNPC = Instantiate(futureGuyNPCPrefab, trasnformFutureGuyNPC.position, Quaternion.identity, transform.parent);

		StartCoroutine(ClosePortal());
	}

	IEnumerator ClosePortal() {
		// Close Portal
		FMODUnity.RuntimeManager.PlayOneShot("event:/SFX/Portal do Tempo");
		yield return new WaitForSeconds(1.25f);
		instancePortal1.GetComponent<Animator>().Play("Close");
	}

	public void ByeCar() {
		if (GameManager.instance.completedFutureGuy) {

			VariableStorage varStore = FindObjectOfType<DialogueRunner>().GetComponent<VariableStorage>();
			varStore.SetValue("$completedAll", true);
			GameManager.instance.completedAll = true;

			//Destroy Future Guy
			Destroy(instanceFutureGuyNPC);
			// Open Portal
			StartCoroutine(OpenPortal2());
			// Move Car
			instanceCar.GetComponent<Animator>().Play("Bye");
			FMODUnity.RuntimeManager.PlayOneShot("event:/SFX/Fusca saindo");
			StartCoroutine(ClosePorta2());
		}
	}

	IEnumerator OpenPortal2() {
		instancePortal2 = Instantiate(portal2Prefab, transformPortal2.position, Quaternion.identity, transform.parent);
		FMODUnity.RuntimeManager.PlayOneShot("event:/SFX/Portal do Tempo");
		yield return new WaitForSeconds(1.25f);
		instancePortal2.GetComponent<Animator>().Play("Open");

	}

	public void DestoryCar() {
		// Destroy Car
		Destroy(instanceCar);
	}

	IEnumerator ClosePorta2() {
		// Close Portal
		yield return new WaitForSeconds(6.75f);
		FMODUnity.RuntimeManager.PlayOneShot("event:/SFX/Portal do Tempo");
		yield return new WaitForSeconds(1.25f);
		instancePortal2.GetComponent<Animator>().Play("Close");
	}
}
