using UnityEngine;
//using System.Collections;

/// <summary>
/// Player controller & behavior
/// </summary>
public class PlayerScript : MonoBehaviour {

	/// <summary>
	/// 0 - The speed of the ship
	/// </summary>
	public Vector2 speed = new Vector2(25, 25);

	// 1 - Store the movement
	private Vector2 movement;
	private Rigidbody2D rigidBodyComponent;

	// Use this for initialization
	void Start () {
		Debug.Log ("In PlayerScript start");
	}
	
	// Update is called once per frame
	void Update () {
		// 2 - Retrieve axis information
		float inputX = Input.GetAxis ("Horizontal");
		float inputY = Input.GetAxis ("Vertical");

		// 3 - Movement per direction
		movement = new Vector2 (speed.x * inputX, speed.y * inputY);
	
		// 5 - Shooting
		// - read the input from a fire button (click or ctrl by default)
		// - retrieve the weapon script
		// - call WeaponScript.Attack(false)
		bool shoot = Input.GetButtonDown ("Fire1");
		shoot |= Input.GetButtonDown ("Fire2");
		// Careful: For Mac users, use mouse "click + arrow" instead of "ctrl + arrow"

		if (shoot) {
			WeaponScript weapon = GetComponent<WeaponScript>();
			if (weapon != null) {
				// pass false since player isn't enemy
				weapon.Attack(false);
			}
		}
	}

	void FixedUpdate() {
		// 4 - Move the game object
		if (rigidBodyComponent == null) {
			rigidBodyComponent = GetComponent<Rigidbody2D>();
		}

		rigidBodyComponent.velocity = movement;
	}
}
