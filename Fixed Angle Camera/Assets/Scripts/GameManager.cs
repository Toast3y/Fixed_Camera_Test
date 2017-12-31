using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public List<GameObject> pauseList;
	public GameObject player;
	public GameObject fade;
	public GameObject inventoryManager;
	public bool paused;
	public bool inventoryOpen;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	//Pause game functions
	public void PauseGame() {
		//Suspend all threads (not possible, consider "pause loop" within them?)
		//Lock controls bar select input
		//Play partial fade out
		//Display pause text

		//Set timescale to zero so deltaTime-dependent operations don't impact the objects and all animations freeze
		//Animations can be set to played independently of timescale, so this isn't an issue
		Time.timeScale = 0;

		fade.SetActive(true);

		paused = true;

		foreach (GameObject objectToPause in pauseList) {

		}
	}

	public void UnpauseGame() {
		//Like above, but in reverse.

		foreach (GameObject objectToPause in pauseList) {

		}

		paused = false;

		fade.SetActive(false);

		Time.timeScale = 1;
	}


	//Inventory functions
	public void OpenInventory() {
		inventoryOpen = true;
		inventoryManager.GetComponent<InventoryManager>().InitializeInventory();
		inventoryManager.SetActive(true);
		PauseGame();
	}

	public void CloseInvetory() {
		inventoryOpen = false;
		inventoryManager.SetActive(false);
		UnpauseGame();
	}


	//Control locking functions
	public void LockControls() {
		//Prevent most or all player input during animations or cutscenes.
		player.GetComponent<SimpleMove>().animationIsPlaying = true;
	}

	public void UnlockControls() {
		//Unlock all controls, like above, but in reverse.
		player.GetComponent<SimpleMove>().animationIsPlaying = false;
	}
}
