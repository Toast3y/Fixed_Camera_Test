﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItem_EmptySlot : MonoBehaviour {

	public GameObject cursor;

	public InventoryItem item;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void SetCursorStatus(bool state) {
		cursor.SetActive(state);
	}

}
