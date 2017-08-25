using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMove : MonoBehaviour {

	public float moveSpeed_forward;
	public float moveSpeed_backward;
	public float turnSpeed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//Move forward or back
		if (Input.GetKey(KeyCode.W)) {
			Debug.Log("Move forward");

			//Move along the characters Z axis
			//gameObject.transform.position = gameObject.transform.position + (new Vector3(0,0,moveSpeed_forward) * Time.deltaTime );
			gameObject.transform.Translate(Vector3.forward * moveSpeed_forward * Time.deltaTime);
		}
		else if (Input.GetKey(KeyCode.S)) {
			Debug.Log("Move back");
			//gameObject.transform.position = gameObject.transform.position + (new Vector3(0,0,-moveSpeed_backward) * Time.deltaTime );
			gameObject.transform.Translate(Vector3.forward * -moveSpeed_backward * Time.deltaTime);
		}

		if (Input.GetKey(KeyCode.A)) {
			Debug.Log("Turn Left");
			gameObject.transform.Rotate(Vector3.up, -turnSpeed * Time.deltaTime);
		}
		else if (Input.GetKey(KeyCode.D)) {
			Debug.Log("Turn Right");
			gameObject.transform.Rotate(Vector3.up, turnSpeed * Time.deltaTime);
		}
	}
}
