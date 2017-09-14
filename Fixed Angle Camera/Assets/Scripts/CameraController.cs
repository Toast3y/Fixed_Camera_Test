using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public Camera mainCamera;

	public List<Camera> sceneCameras;

	public bool isToggleable;

	// Use this for initialization
	void Start () {
		isToggleable = true;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnTriggerEnter(Collider other) {
		if (other.name == "Player" && isToggleable) {
			mainCamera.GetComponent<Camera>().enabled = true;
		}
	}

	private void OnTriggerStay(Collider other) {
		
	}

	private void OnTriggerExit(Collider other) {
		if (other.name == "Player" && isToggleable) {
			mainCamera.GetComponent<Camera>().enabled = false;
		}
	}

	public void SetIsToggleable(bool _isToggleable) {
		isToggleable = _isToggleable;
	}

	public void ToggleCamera(bool _state) {
		//Toggle the camera if it's allowed.
		if (isToggleable) {
			mainCamera.GetComponent<Camera>().enabled = _state;
		}
	}
}
