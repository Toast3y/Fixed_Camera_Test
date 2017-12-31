using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItem_EmptySlot : MonoBehaviour {

	public GameObject cursor;

	public InventoryItem item;
	public Sprite currentItemSprite;

	public int slotNum;

	public bool isEmpty;

	// Use this for initialization
	void Start () {
		isEmpty = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void SetCursorStatus(bool state) {
		cursor.SetActive(state);
	}

	public void SetItem(InventoryItem _item) {
		item = _item;
	}

	public void SetCurrentItemSprite() {
		//Current item sprite is called when the new item is set
		currentItemSprite = item.itemSprite;
		gameObject.GetComponent<Image>().sprite = currentItemSprite;
	}

}
