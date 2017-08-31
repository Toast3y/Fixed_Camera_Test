using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyType_Chadwick : EnemyType {

	// Use this for initialization
	void Start () {
		health = 10;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public override void TakeDamage() {
		//Modify this as expected of the behaviour of the enemy
		//Death animations, stuns, etc.
		health--;

		if (health <= 0) {
			Death();
		}
	}

	public override void Death() {
		Destroy(this.gameObject);
	}

	public override void OnPauseGame() {

	}
}
