using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProximityRenderer : MonoBehaviour {

	[Header("Basic Options")]
	public Color cubeColour;
	public Camera associatedCamera;
	public GameObject room;

	[Header("Object Tracking")]
	public bool track;
	public GameObject itemToTrack;

	[Header("Transition Handling")]
	public bool isTransition;


	void OnDrawGizmos() {
		Gizmos.color = cubeColour;
		Gizmos.DrawCube(gameObject.transform.position, gameObject.transform.localScale);
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (track) {
			transform.LookAt(itemToTrack.transform.position);
		}
	}

	private void OnTriggerEnter(Collider other) {
		//Debug.Log("Camera Switch");

		if (other.name == "Player") {
			associatedCamera.GetComponent<Camera>().enabled = true;
			room.GetComponent<CameraController>().ToggleCamera(false);
		}
	}

	private void OnTriggerExit(Collider other) {
		if (other.name == "Player") {
			room.GetComponent<CameraController>().ToggleCamera(true);
			associatedCamera.GetComponent<Camera>().enabled = false;
		}
	}

}
