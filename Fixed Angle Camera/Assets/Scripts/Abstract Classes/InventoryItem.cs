using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InventoryItem : MonoBehaviour {

	public string itemName;

	public Sprite itemSprite;

	public string GetItemName() {
		return itemName;
	}

	public abstract void OnUse();

	public abstract void OnInspect();

	public abstract void OnCombine();

}
