using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionController : MonoBehaviour {
	//Class used to control camera shifts to better control frame rate dips.

	[Header("Room Objects")]
	public GameObject room1;
	public GameObject room2;
	[Header("Basic Options")]
	public Color cubeColour;


	void OnDrawGizmos() {
		Gizmos.color = cubeColour;
		Gizmos.DrawCube(gameObject.transform.position, gameObject.transform.localScale);
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnTriggerEnter(Collider other) {
		if (other.name == "Player") {
			room1.GetComponent<CameraController>().SetIsToggleable(false);
			room2.GetComponent<CameraController>().SetIsToggleable(false);
		}
	}

	private void OnTriggerExit(Collider other) {
		if (other.name == "Player") {
			room1.GetComponent<CameraController>().SetIsToggleable(true);
			room2.GetComponent<CameraController>().SetIsToggleable(true);
		}
	}
}
