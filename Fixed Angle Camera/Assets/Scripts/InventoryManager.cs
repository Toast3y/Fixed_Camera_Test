using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour {

	public int invPointer;
	public int invSize;

	public GameObject activeInvSlot;

	public GameObject invSlot1;
	public GameObject invSlot2;
	public GameObject invSlot3;
	public GameObject invSlot4;
	public GameObject invSlot5;
	public GameObject invSlot6;
	public GameObject invSlot7;
	public GameObject invSlot8;

	private bool allowVerticalMovement;
	private bool allowHorizontalMovement;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	public void InitializeInventory() {
		//Set default settings when the inventory is opened.
		if (activeInvSlot != null) {
			activeInvSlot.GetComponent<InventoryItem_EmptySlot>().SetCursorStatus(false);
		}

		invPointer = 1;
		activeInvSlot = invSlot1;
		UpdateCursor();

	}

	public void InventoryControls() {
		//Use the data in the inventory to determine how the controls react.
		//Left column: odd numbers
		//Right column: even numbers

		if (allowHorizontalMovement == false || allowVerticalMovement == false) {
			ToggleCursorMovement();
		}

		if (Input.GetAxis("DPadXAxis") > 0 && allowHorizontalMovement == true) {
			//Debug.Log("Inventory Input: Right");
			if (invPointer < invSize) {
				invPointer++;
				UpdateCursor();
				allowHorizontalMovement = false;
			}
		}

		if (Input.GetAxis("DPadXAxis") < 0 && allowHorizontalMovement == true) {
			//Debug.Log("Inventory Input: Left");
			if (invPointer > 1) {
				invPointer--;
				UpdateCursor();
				allowHorizontalMovement = false;
			}
		}

		if (Input.GetAxis("DPadYAxis") > 0 && allowVerticalMovement == true) {
			//MoveForward();
			//Debug.Log("Inventory Input: Up");
			if (invPointer > 2) {
				invPointer = invPointer - 2;
				UpdateCursor();
				allowVerticalMovement = false;
			}
		}

		if (Input.GetAxis("DPadYAxis") < 0 && allowVerticalMovement == true) {
			//MoveBackward();
			//Debug.Log("Inventory Input: Down");
			if (invPointer < (invSize - 1)) {
				invPointer = invPointer + 2;
				UpdateCursor();
				allowVerticalMovement = false;
			}
		}

	}

	public void ToggleCursorMovement() {
		//Set the boolean if the player let up on the axis
		if (Input.GetAxis("DPadXAxis") > -0.1 && Input.GetAxis("DPadXAxis") < 0.1) {
			allowHorizontalMovement = true;
		}

		if (Input.GetAxis("DPadYAxis") > -0.1 && Input.GetAxis("DPadYAxis") < 0.1) {
			allowVerticalMovement = true;
		}
	}

	public void UpdateCursor() {

		//Deactivate the cursor on the current active inventory slot
		//Set the active inventory slot to the designated space
		//Activate the cursor in that space.
		//If there's any special items that take up 2 slots, handle it here.

		activeInvSlot.GetComponent<InventoryItem_EmptySlot>().SetCursorStatus(false);

		switch (invPointer) {
			case 1:
				activeInvSlot = invSlot1;
				break;
			case 2:
				activeInvSlot = invSlot2;
				break;
			case 3:
				activeInvSlot = invSlot3;
				break;
			case 4:
				activeInvSlot = invSlot4;
				break;
			case 5:
				activeInvSlot = invSlot5;
				break;
			case 6:
				activeInvSlot = invSlot6;
				break;
			case 7:
				activeInvSlot = invSlot7;
				break;
			case 8:
				activeInvSlot = invSlot8;
				break;
		}

		activeInvSlot.GetComponent<InventoryItem_EmptySlot>().SetCursorStatus(true);
	}


	public void SortInventory() {
		//Sort the inventory whenever an item is removed or a heavy item is added
		
	}


}
