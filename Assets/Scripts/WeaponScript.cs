using UnityEngine;
using System.Collections;

/// <summary>
/// Launch projectile from front of the game object it
/// is attached to.
/// This script will be reused everywhere - players, enemies, etc.
/// </summary>
public class WeaponScript : MonoBehaviour {

	// Designer variables

	/// <summary>
	/// Projectile prefab for shooting.
	/// Needed to set the shot that will be used with this weapon
	/// </summary>
	public Transform shotPreFab;

	/// <summary>
	/// Cooldown in seconds between 2 shots
	/// </summary>
	public float shootingRate = 0.25f;

	// cooldown
	// We use a simple cooldown mechanism. If it is greater than 0,
	// we simply cannot shoot. We substract the elapsed time at 
	// each frame (Update method).
	private float shootCooldown;

	// Use this for initialization
	void Start () {
		shootCooldown = 0f;
	}
	
	// Update is called once per frame
	void Update () {
		if (shootCooldown > 0) {
			shootCooldown -= Time.deltaTime;
		}
	}

	// Shooting from another script

	/// <summary>
	/// Create a new projectile if possible
	/// </summary>
	/// <param name="isEnemy"></param>
	/// 
	/// Main purpose of this script: being called from another one.
	/// This is why we have a public method that can create the projectile.
	/// Once the projectile is instantiated, we retrieve the scripts of the shot object 
	/// and override some variables.
	public void Attack(bool isEnemy) {
		if (CanAttack) {
			shootCooldown = shootingRate;

			// create a new shot
			var shotTransform = Instantiate(shotPreFab) as Transform;

			// assign position
			shotTransform.position = transform.position;

			// isEnemy?
			ShotScript shot = shotTransform.gameObject.GetComponent<ShotScript>();
			if (shot != null) {
				shot.isEnemyShot = isEnemy;
			}

			// make the weapon shot always towards it
			MoveScript move = shotTransform.gameObject.GetComponent<MoveScript>();
			if (move != null) {
				// towards in 2D space is right of the sprite
				move.direction = this.transform.right;
			}
		}
	}

	/// <summary>
	/// Is the weapon ready to create a new projectile?
	/// </summary>
	public bool CanAttack {
		get {
			// If it is greater than 0, we simply cannot shoot
			return shootCooldown <= 0f;
		}
	}
}
