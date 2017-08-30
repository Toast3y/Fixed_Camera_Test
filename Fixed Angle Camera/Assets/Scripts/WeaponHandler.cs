using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHandler : MonoBehaviour {

	public GameObject marker;
	public WeaponType equippedWeapon;
	public int ammoCount;

	// Use this for initialization
	void Start () {
		equippedWeapon = new WeaponType_Pistol();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void FireWeapon() {
		equippedWeapon.FireWeapon(marker);
	}
}
