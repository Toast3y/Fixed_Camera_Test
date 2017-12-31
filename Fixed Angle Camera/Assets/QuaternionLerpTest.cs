using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuaternionLerpTest : MonoBehaviour {

	Quaternion playerRotation;
	Quaternion newRotation;
	float rotationSpeed = 0.1f;

	// Use this for initialization
	void Start () {
		playerRotation = gameObject.transform.rotation;
		newRotation = new Quaternion(playerRotation.x, playerRotation.y - 180.0f, playerRotation.z, playerRotation.w);
	}
	
	// Update is called once per frame
	void Update () {
		gameObject.transform.rotation = Quaternion.Lerp(playerRotation, newRotation, Time.time * rotationSpeed);
	}
}
