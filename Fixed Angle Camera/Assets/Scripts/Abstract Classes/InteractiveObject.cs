using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InteractiveObject : MonoBehaviour {

	public GameObject gameManager;
	public int priorityNumber;
	public bool isInteractive = true;

	// Use this for initialization
	void Start() {

	}

	// Update is called once per frame
	void Update() {

	}

	//Invoke this if the object in question needs to be removed from the interactive object list.
	public void InteractionRemoval() {
		var hitbox = GameObject.Find("Interaction Hitbox");

		if (hitbox != null) {
			hitbox.GetComponent<InteractionScanner>().RemoveObject(gameObject);
		}
	}

	public void SetIsInteractive(bool _isInteractive) {
		isInteractive = _isInteractive;
	}

	public abstract void Interaction();
}
