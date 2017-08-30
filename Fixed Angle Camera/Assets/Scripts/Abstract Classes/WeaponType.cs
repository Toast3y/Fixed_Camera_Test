using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponType{

	//Weapon name and type
	public string weaponName;
	//Weapon stats
	public float weaponRange;
	public int weaponDamage;
	public int weaponMaxAmmo;

	//Weapon boolean values
	public bool isMelee;
	public bool isRanged;

	public bool isHitscan;
	public bool isProjectile;

	public bool isInfiniteAmmo;

	//Weapon inventory size and weight
	public int weaponSize;
	public float weaponWeight;

	public abstract void FireWeapon(GameObject muzzle);

	public abstract void ReadyWeapon();

	public abstract void ReloadWeapon();

	//public abstract void OnCreate();

}
