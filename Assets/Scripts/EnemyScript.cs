using UnityEngine;
using System.Collections;

/// <summary>
/// Enemy generic behavior
/// A simple behavior - trigger the weapon at each frame. A kind of auto-fire
/// </summary>
public class EnemyScript : MonoBehaviour {

	private WeaponScript[] weapons;

	private bool hasSpawn;
	private MoveScript moveScript;

	void Awake() {
		Debug.Log ("In EnemyScript Awake");
		// Retrieve the weapons only once
		weapons = GetComponentsInChildren<WeaponScript> ();

		// Retrieve scripts to disable when not spawned
		moveScript = GetComponent<MoveScript> ();
	}

	// Use this for initialization
	void Start () {
		Debug.Log ("In EnemyScript Start");

		hasSpawn = false;

		// --- disable everything ---
		// disable collider
		GetComponent<Collider2D> ().enabled = false;
		// disable moving
		moveScript.enabled = false;
		// disable shooting
		foreach(WeaponScript weapon in weapons) {
			weapon.enabled = false;
		}
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log ("In EnemyScript Update");

		// check if enemy has spawned
		if (hasSpawn == false) {
			// spawn enemy if renderer is inside the camera sight
			if (GetComponent<Renderer>().IsVisibleFrom(Camera.main)) {
				Spawn();
			}
		} else {

			// auto-fire each weapon
			foreach (WeaponScript weapon in weapons) {
				if (weapon != null && weapon.CanAttack) {
					weapon.Attack (true);
				}
			}

			// destroy the game object if outside the camera sight
			if ((GetComponent<Renderer>().IsVisibleFrom(Camera.main)) == false) {
				Debug.Log("Destroying enemy...");
				Destroy(gameObject);
			}
		}
	}

	// activate itself
	private void Spawn() {
		hasSpawn = true;
		
		// --- enable everything ---
		// enable collider
		GetComponent<Collider2D> ().enabled = true;
		// enable moving
		moveScript.enabled = true;
		// enable shooting
		foreach(WeaponScript weapon in weapons) {
			weapon.enabled = true;
		}
	}
}
