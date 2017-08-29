using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public Camera mainCamera;

	public List<Camera> sceneCameras;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnTriggerEnter(Collider other) {
		if (other.name == "Player") {
			mainCamera.GetComponent<Camera>().enabled = true;
		}
	}

	private void OnTriggerStay(Collider other) {
		
	}

	private void OnTriggerExit(Collider other) {
		if (other.name == "Player") {
			mainCamera.GetComponent<Camera>().enabled = false;
		}
	}
}
