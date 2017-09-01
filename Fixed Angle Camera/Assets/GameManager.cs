using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public List<GameObject> pauseList;
	public GameObject fade;
	public bool paused;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void PauseGame() {
		//Suspend all threads (not possible, consider "pause loop" within them?)
		//Lock controls bar select input
		//Play partial fade out
		//Display pause text

		//Set timescale to zero so deltaTime-dependent operations don't impact the objects and all animations freeze
		Time.timeScale = 0;

		fade.active = true;

		paused = true;

		foreach (GameObject objectToPause in pauseList) {

		}
	}

	public void UnpauseGame() {
		//Like above, but in reverse.

		foreach (GameObject objectToPause in pauseList) {

		}

		paused = false;

		fade.active = false;

		Time.timeScale = 1;
	}
}
