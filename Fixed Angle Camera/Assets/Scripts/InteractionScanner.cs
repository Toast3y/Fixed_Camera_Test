using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionScanner : MonoBehaviour {

	public GameObject priorityInteractable;
	[Header("List")]
	public List<GameObject> interactableInRange;

	private int objectPriority;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnTriggerEnter(Collider other) {
		if (other.gameObject.GetComponent<InteractiveObject>() != null) {
			interactableInRange.Add(other.gameObject);

			int priorityNum = other.gameObject.GetComponent<InteractiveObject>().priorityNumber;

			if (priorityNum >= objectPriority) {
				//Set the newly entered object as the priority object.
				priorityInteractable = other.gameObject;
				objectPriority = priorityNum;
			}
		}
	}

	private void OnTriggerExit(Collider other) {

		if (other.gameObject.GetComponent<InteractiveObject>() != null) {
			//Remove the object, and rescan for priority.
			interactableInRange.Remove(other.gameObject);

			//Set object priority lowest.
			priorityInteractable = null;
			objectPriority = -1;

			foreach (GameObject thing in interactableInRange) {

				int newPriority = thing.GetComponent<InteractiveObject>().priorityNumber;

				if (newPriority >= objectPriority) {
					objectPriority = newPriority;
					priorityInteractable = thing;
				}
			}
		}
	}

	public void InteractWIthObject() {
		if (priorityInteractable != null) {
			priorityInteractable.GetComponent<InteractiveObject>().Interaction();
		}
	}
}
