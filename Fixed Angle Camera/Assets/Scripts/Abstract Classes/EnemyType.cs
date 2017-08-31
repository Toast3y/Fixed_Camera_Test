using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyType : MonoBehaviour{

	public int health;

	public abstract void TakeDamage();

	public abstract void Death();

	public abstract void OnPauseGame();
}
