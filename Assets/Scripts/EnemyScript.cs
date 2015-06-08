using UnityEngine;
using System.Collections;

/// <summary>
/// Enemy generic behavior
/// A simple behavior - trigger the weapon at each frame. A kind of auto-fire
/// </summary>
public class EnemyScript : MonoBehaviour {

	private WeaponScript weapon;

	void Awake() {
		// Retrieve the weapon only once
		weapon = GetComponent<WeaponScript> ();
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		// auto-fire
		if (weapon != null && weapon.CanAttack) {
			weapon.Attack(true);
		}
	}
}
