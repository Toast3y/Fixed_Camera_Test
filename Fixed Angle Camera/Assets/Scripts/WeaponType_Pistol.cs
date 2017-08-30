using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponType_Pistol : WeaponType {

	private int layermask;

	// Use this for initialization
	void Start () {
		weaponName = "Pistol";

		weaponDamage = 12;
		weaponRange = 24f;
		weaponMaxAmmo = 15;

		isMelee = false;
		isRanged = true;

		isHitscan = true;
		isProjectile = false;

		isInfiniteAmmo = false;

		//Size is how many hands it takes to wield (aka one or two handed)
		//Weight is a modifier to movement speed while using it.
		weaponSize = 1;
		weaponWeight = 1f;

		layermask = 1 << 9;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	

	public override void FireWeapon(GameObject muzzle) {
		//Raycast using the specified parameters
		RaycastHit hit;
		if (Physics.Raycast(muzzle.transform.position, muzzle.transform.forward, out hit, weaponRange, layermask)) {
			Debug.DrawRay(muzzle.transform.position, muzzle.transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
			Debug.Log("Hit!");
		}
		else {
			Debug.DrawRay(muzzle.transform.position, muzzle.transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
			Debug.Log("No hit!");
		}
	}

	public override void ReadyWeapon() {
		throw new System.NotImplementedException();
	}

	public override void ReloadWeapon() {
		throw new System.NotImplementedException();
	}
}
