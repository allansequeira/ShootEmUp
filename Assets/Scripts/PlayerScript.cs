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

		// --- keep player inside camera bounds ---
		// Get the camera edges and make sure the player position (the center of the sprite) is 
		// inside the area borders
		var dist = (transform.position - Camera.main.transform.position).z;
		var leftBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, dist)).x;
		var rightBorder = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, dist)).x;
		var topBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, dist)).y;
		var bottomBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 1, dist)).y;
		
		transform.position = new Vector3(
			Mathf.Clamp(transform.position.x, leftBorder, rightBorder),
			Mathf.Clamp(transform.position.y, topBorder, bottomBorder),
			transform.position.z
			);
		// --- keep player inside camera bounds ---
	}

	void FixedUpdate() {
		// 4 - Move the game object
		if (rigidBodyComponent == null) {
			rigidBodyComponent = GetComponent<Rigidbody2D>();
		}

		rigidBodyComponent.velocity = movement;
	}

	/// <summary>
	/// Handle collision between player and enemy.
	/// Damage both player and enemy using the HealthScript component
	/// </summary>
	/// <param name="collision">Collision.</param>
	void OnCollisionEnter2D(Collision2D collision) {
		bool damagePlayer = false;

		// collision with enemy
		EnemyScript enemy = collision.gameObject.GetComponent<EnemyScript> ();
		if (enemy != null) {
			// kill the enemy
			HealthScript enemyHealth = enemy.GetComponent<HealthScript>();
			if (enemyHealth != null) {
				enemyHealth.Damage(enemyHealth.hp);
			}

			// this is redundant since we could code "damaging the player" here
			damagePlayer = true;
		}

		// damage the player
		if (damagePlayer) {
			HealthScript playerHealth = this.GetComponent<HealthScript>();
			if (playerHealth != null) {
				playerHealth.Damage(1);
			}
		}
	}
}
