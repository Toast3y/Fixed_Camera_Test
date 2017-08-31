using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponType_Pistol : WeaponType {

	private int layermask;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public WeaponType_Pistol() {
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

		layermask = (1 << 9) | (1 << 10);
		Debug.Log("Weapon created!");
	}

	public override void FireWeapon(GameObject muzzle) {
		//Raycast using the specified parameters
		RaycastHit hit;
		if (Physics.Raycast(muzzle.transform.position, muzzle.transform.forward, out hit, weaponRange, layermask)) {
			Debug.DrawRay(muzzle.transform.position, muzzle.transform.TransformDirection(Vector3.forward) * hit.distance, Color.red);
			Debug.Log("Hit!");

			if (hit.collider.gameObject.layer == 9) {
				Debug.Log("Enemy Hit!");
				hit.collider.gameObject.GetComponent<EnemyType>().TakeDamage();
			}
			else if (hit.collider.gameObject.layer == 10) {
				Debug.Log("Scenery Hit!");
			}
		}
		else {
			Debug.DrawRay(muzzle.transform.position, muzzle.transform.TransformDirection(Vector3.forward) * weaponRange, Color.red);
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
