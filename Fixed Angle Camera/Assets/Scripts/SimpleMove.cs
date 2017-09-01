using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMove : MonoBehaviour {

	public GameObject gameManager;
	public GameObject reticle;
	public GameObject weapon;
	public GameObject interactiveHitbox;

	public Material reddot;
	public Material standard_colour;

	public float moveSpeed_forward;
	public float moveSpeed_backward;
	public float turnSpeed;

	public float runMultiplier;

	public bool reticle_colour = false;
	public bool paused = false;
	public bool menuOpen = false;
	public bool inventoryOpen = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log("recompile");
		//Poll the games controls and do the appropriate action

		if (!paused) {
			if (Input.GetButton("Stance")) {
				//Controls for use while in fighting stance.
				StanceControls();
			}
			else {
				//Standard non-stance movement controls.
				RegularControls();
			}
		}
		else {
			if (paused && menuOpen) {
				//Options menu

			}
			else if (paused && inventoryOpen) {
				//Inventory menu

			}
			else {
				//Pause Screen
				PauseControls();
			}
		}

		

		if (Input.GetAxisRaw("DPadYAxis") <= 0.1 && Input.GetAxisRaw("DPadYAxis") >= -0.1 || Input.GetButtonUp("Stance")) {
			ResetReticle();
			//ResetMaterialColour();
		}

	}

	//Generic Controls
	private void RegularControls() {
		if (reticle_colour == true) {
			ResetMaterialColour();
			reticle_colour = false;
		}

		//Generic controls
		if (Input.GetButtonDown("Interact")) {
			interactiveHitbox.GetComponent<InteractionScanner>().InteractWIthObject();
		}

		if (Input.GetButton("Run")) {

		}

		if (Input.GetButtonDown("Cancel")) {

		}

		if (Input.GetButtonDown("Inventory")) {

		}

		//Movement controls
		if (Input.GetAxis("DPadXAxis") > 0) {
			TurnRight();
		}

		if (Input.GetAxis("DPadXAxis") < 0) {
			TurnLeft();
		}

		if (Input.GetAxis("DPadYAxis") > 0) {
			MoveForward();
		}

		if (Input.GetAxis("DPadYAxis") < 0) {
			MoveBackward();
		}

		//Misc Controls
		if (Input.GetButtonDown("Pause")) {
			PauseGame();
		}

		if (Input.GetButtonDown("Options")) {

		}
	}


	//Stance Controls
	private void StanceControls() {
		if (reticle_colour == false) {
			ChangeMaterialColour();
			reticle_colour = true;
		}

		//Generic controls
		if (Input.GetButtonDown("Interact")) {
			Debug.Log("Fire Weapon");
			weapon.GetComponent<WeaponHandler>().FireWeapon();
		}

		if (Input.GetButton("Run")) {
			//Reload weapon
		}

		if (Input.GetButtonDown("Cancel")) {
			//Use secondary weapon
		}

		if (Input.GetButtonDown("Inventory")) {

		}

		//Movement controls
		if (Input.GetAxis("DPadXAxis") > 0) {
			TurnRight();
		}

		if (Input.GetAxis("DPadXAxis") < 0) {
			TurnLeft();
		}

		if (Input.GetAxis("DPadYAxis") > 0) {
			LookUp();
		}

		if (Input.GetAxis("DPadYAxis") < 0) {
			LookDown();
		}

		//Misc Controls
		if (Input.GetButtonDown("Pause")) {

		}

		if (Input.GetButtonDown("Options")) {

		}
	}

	private void PauseControls() {
		//Generic controls
		if (Input.GetButtonDown("Interact")) {
			
		}

		if (Input.GetButton("Run")) {

		}

		if (Input.GetButtonDown("Cancel")) {

		}

		if (Input.GetButtonDown("Inventory")) {

		}

		//Movement controls
		if (Input.GetAxis("DPadXAxis") > 0) {
			
		}

		if (Input.GetAxis("DPadXAxis") < 0) {
			
		}

		if (Input.GetAxis("DPadYAxis") > 0) {
			
		}

		if (Input.GetAxis("DPadYAxis") < 0) {
			
		}

		//Misc Controls
		if (Input.GetButtonDown("Pause")) {
			UnpauseGame();
		}

		if (Input.GetButtonDown("Options")) {

		}
	}

	private void InventoryControls() {
		//Generic controls
		if (Input.GetButtonDown("Interact")) {
			
		}

		if (Input.GetButton("Run")) {

		}

		if (Input.GetButtonDown("Cancel")) {

		}

		if (Input.GetButtonDown("Inventory")) {

		}

		//Movement controls
		if (Input.GetAxis("DPadXAxis") > 0) {
			
		}

		if (Input.GetAxis("DPadXAxis") < 0) {
			
		}

		if (Input.GetAxis("DPadYAxis") > 0) {
			
		}

		if (Input.GetAxis("DPadYAxis") < 0) {
			
		}

		//Misc Controls
		if (Input.GetButtonDown("Pause")) {

		}

		if (Input.GetButtonDown("Options")) {

		}
	}

	private void MenuControls() {
		//Generic controls
		if (Input.GetButtonDown("Interact")) {
			
		}

		if (Input.GetButton("Run")) {

		}

		if (Input.GetButtonDown("Cancel")) {

		}

		if (Input.GetButtonDown("Inventory")) {

		}

		//Movement controls
		if (Input.GetAxis("DPadXAxis") > 0) {
			
		}

		if (Input.GetAxis("DPadXAxis") < 0) {
			
		}

		if (Input.GetAxis("DPadYAxis") > 0) {
			
		}

		if (Input.GetAxis("DPadYAxis") < 0) {
			
		}

		//Misc Controls
		if (Input.GetButtonDown("Pause")) {

		}

		if (Input.GetButtonDown("Options")) {

		}
	}




	//Original "tank" controls
	private void MoveForward() {
		if (Input.GetButton("Run")) {
			gameObject.transform.Translate(Vector3.forward * (moveSpeed_forward * runMultiplier) * Time.deltaTime);
		}
		else {
			gameObject.transform.Translate(Vector3.forward * moveSpeed_forward * Time.deltaTime);
		}
	}

	private void MoveBackward() {
		/*if (Input.GetButtonDown("Run")) {
			//Perform a quick turn
			//gameObject.transform.Rotate(Vector3.up, -spinSpeed * Time.deltaTime);
		}
		else {
			gameObject.transform.Translate(Vector3.forward * -moveSpeed_backward * Time.deltaTime);
		}*/
		gameObject.transform.Translate(Vector3.forward * -moveSpeed_backward * Time.deltaTime);
	}

	private void TurnLeft() {
		gameObject.transform.Rotate(Vector3.up, -turnSpeed * Time.deltaTime);
	}

	private void TurnRight() {
		gameObject.transform.Rotate(Vector3.up, turnSpeed * Time.deltaTime);
	}

	//"Alternate" controls using joystick movement relative to active camera position.
	//TODO: Figure this out.

	private void LookUp() {
		reticle.transform.localPosition = new Vector3(0, 0.5f, 0.75f);
		//reticle.transform.rotation = new Quaternion(-30.0f, gameObject.transform.rotation.y, gameObject.transform.rotation.z, gameObject.transform.rotation.w);
	}

	private void LookDown() {
		reticle.transform.localPosition = new Vector3(0, -0.5f, 0.75f);
		//reticle.transform.rotation = new Quaternion(30.0f, 0, 0, 0);
	}

	private void ResetReticle() {
		reticle.transform.localPosition = new Vector3(0, 0, 0.75f);
	}

	private void ChangeMaterialColour() {
		reticle.GetComponent<Renderer>().material = reddot;
	}

	private void ResetMaterialColour() {
		reticle.GetComponent<Renderer>().material = standard_colour;
		
	}

	//System control methods
	private void PauseGame() {
		paused = true;
		gameManager.GetComponent<GameManager>().PauseGame();
		Debug.Log("Game paused");
	}

	private void UnpauseGame() {
		paused = false;
		gameManager.GetComponent<GameManager>().UnpauseGame();
		Debug.Log("Game unpaused");
	}
}
