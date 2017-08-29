using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveObject_Door : InteractiveObject {

	void OnDrawGizmos() {

	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public override void Interaction() {
		Debug.Log("Door open!");
	}
}
