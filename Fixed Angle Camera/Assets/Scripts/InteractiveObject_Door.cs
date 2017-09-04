using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class InteractiveObject_Door : InteractiveObject {

	public GameObject meshLink;
	public GameObject door;

	void OnDrawGizmos() {

	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public override void Interaction() {

		if (isInteractive) {
			Debug.Log("Door open!");
			StartCoroutine("OpenCloseDoor");
			//StartCoroutine("MoveThroughDoor");

			/*door.GetComponent<NavMeshObstacle>().carving = false;

			var animate = door.GetComponent<Animator>();
			animate.Play("OpenDoor");
			SetIsInteractive(false);*/
		}

		
	}

	IEnumerator OpenCloseDoor() {

		door.GetComponent<NavMeshObstacle>().carving = false;

		var animate = door.GetComponent<Animator>();
		animate.Play("OpenDoor");
		SetIsInteractive(false);

		yield return new WaitForSeconds(8.0f);

		door.GetComponent<NavMeshObstacle>().carving = true;
		animate.Play("CloseDoor");
		SetIsInteractive(true);

		yield return null;
	}

	IEnumerator MoveThroughDoor() {
		meshLink.GetComponent<OffMeshLink>().activated = true;

		//Remove player control
		gameManager.GetComponent<GameManager>().LockControls();

		//Line the player up to the nearest bridge on the mesh link
		Vector3 alignPos;
		Vector3 alignLook;
		if (Vector3.Distance(meshLink.GetComponent<OffMeshLink>().startTransform.position, gameManager.GetComponent<GameManager>().player.transform.position) < Vector3.Distance(meshLink.GetComponent<OffMeshLink>().endTransform.position, gameManager.GetComponent<GameManager>().player.transform.position)) {
			alignPos = meshLink.GetComponent<OffMeshLink>().startTransform.position;
			alignLook = meshLink.GetComponent<OffMeshLink>().endTransform.position;
		}
		else {
			alignPos = meshLink.GetComponent<OffMeshLink>().endTransform.position;
			alignLook = meshLink.GetComponent<OffMeshLink>().startTransform.position;
		}

		//Open the door
		var animator = door.GetComponent<Animation>();
		animator.Play("OpenDoor");


		//Wait for animation to finish
		yield return new WaitForSeconds(animator.clip.length);


		//Move player through in the direction of the opposite OffMeshLink

		//Close the door
		animator.Play("CloseDoor");

		//Return player control	
		gameManager.GetComponent<GameManager>().UnlockControls();

		yield return null;
	}

}
