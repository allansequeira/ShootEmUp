using UnityEngine;
using System.Collections;

/// <summary>
/// Enemy generic behavior
/// A simple behavior - trigger the weapon at each frame. A kind of auto-fire
/// </summary>
public class EnemyScript : MonoBehaviour {

	private WeaponScript[] weapons;

	void Awake() {
		Debug.Log ("In EnemyScript Awake");
		// Retrieve the weapons only once
		weapons = GetComponentsInChildren<WeaponScript> ();
	}

	// Use this for initialization
	void Start () {
		Debug.Log ("In EnemyScript Start");
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log ("In EnemyScript Update");

		foreach (WeaponScript weapon in weapons) {
			// auto-fire
			if (weapon != null && weapon.CanAttack) {
				weapon.Attack(true);
			}
		}
	}
}
