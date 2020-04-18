using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;
using Yarn.Unity.Example;

public class Player : MonoBehaviour
{

	public bool automaticStart = false;

	public float speed = 100f;

	Rigidbody2D rbd2D;
	SpriteRenderer sprRenderer;
	Vector2 motion = Vector2.zero;

	Animator anim;

	bool canInteract = false;
	GameObject objInteract;

	public static Player instance;

	private void Awake() {
		if (FindObjectsOfType<Player>().Length > 1) {
			Destroy(gameObject);
		} else {
			DontDestroyOnLoad(gameObject);
			instance = this;
		}
	}

	// Start is called before the first frame update
	void Start() {
		rbd2D = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
		sprRenderer = GetComponent<SpriteRenderer>();

		if (automaticStart) {
			WakeUp();
		} else {
			FindObjectOfType<DialogueRunner>().StartDialogue(GetComponent<NPC>().talkToNode);
		}
	}

	// Update is called once per frame
	void Update() {
		if (GameManager.instance.gameStarted) {
			InputMovement();
			InputInteraction();
			Animation();
		}
	}

	private void InputInteraction() {
		if (Input.GetKeyDown(KeyCode.Z) && canInteract && objInteract) {
			if (objInteract.tag == "Note") {
				if (transform.childCount == 0) {
					anim.SetBool("haveNote", true);
					objInteract.transform.parent = transform;
					objInteract.transform.position = transform.position;
					objInteract.GetComponent<Note>().isPlayer = true;
					objInteract.gameObject.SetActive(false);
					objInteract = null;
					FMODUnity.RuntimeManager.PlayOneShot("event:/SFX/Pegar");
				}
			}else if (objInteract.tag == "NPC"){
				Debug.Log(objInteract.GetComponent<NPC>().talkToNode);
				FindObjectOfType<DialogueRunner>().StartDialogue(objInteract.GetComponent<NPC>().talkToNode);
			}
		} else if (Input.GetKeyDown(KeyCode.X)) {
			if (transform.childCount > 0) {
				anim.SetBool("haveNote", false);
				transform.GetChild(0).GetComponent<Note>().isPlayer = false;
				transform.GetChild(0).gameObject.SetActive(true);
				transform.GetChild(0).gameObject.GetComponent<Note>().placeName = FindObjectOfType<TeleportManager>().currentPlace;
				transform.GetChild(0).transform.position = transform.position;
				transform.GetChild(0).transform.parent = GameObject.FindGameObjectWithTag("Objects").transform;
				FMODUnity.RuntimeManager.PlayOneShot("event:/SFX/Largar");
			}
		}
	}

	private void Animation() {
		if (motion.x != 0 || motion.y != 0) {
			anim.SetBool("isWalking", true);
			sprRenderer.flipX = motion.x == 1f ? false : true;
		} else {
			anim.SetBool("isWalking", false);
		}

		anim.SetInteger("horizontal", (int)motion.x);
		anim.SetInteger("vertical", (int)motion.y);
	}

	private void InputMovement() {
		motion.x = Input.GetAxisRaw("Horizontal");
		motion.y = Input.GetAxisRaw("Vertical");
	}

	// Physic
	void FixedUpdate() {
		Movement();
	}

	private void Movement() {
		rbd2D.velocity = motion.normalized * speed * Time.fixedDeltaTime;
	}

	public void SetPosition(Vector3 newPosition) {
		transform.position = newPosition;
	}

	private void OnTriggerStay2D(Collider2D collision) {
		if (collision.tag == "Note" || collision.tag == "NPC") {
			canInteract = true;
			objInteract = collision.gameObject;
		} 
	}

	private void OnTriggerExit2D(Collider2D collision) {
		if (collision.tag == "Note" || collision.tag == "NPC") {
			canInteract = false;
			objInteract = null;
		}
	}

	public bool HasNote() {
		return anim.GetBool("haveNote");
	}

	public void DestroyNote() {
		anim.SetBool("haveNote", false);
		transform.GetChild(0).gameObject.SetActive(true);
		Destroy(transform.GetChild(0).gameObject);
	}

	public void WakeUp() {
		anim.Play("Idle-Down");
		GameManager.instance.StartGame();
	}
}
