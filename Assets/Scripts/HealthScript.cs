using UnityEngine;
using System.Collections;

/// <summary>
/// Handle hitpoints and damage
/// </summary>
public class HealthScript : MonoBehaviour {

	/// <summary>
	/// Total hitpoints
	/// </summary>
	public int hp = 1;

	/// <summary>
	/// Enemy or Player?
	/// </summary>
	public bool isEnemy = true;

	/// <summary>
	/// Inflicts damage and check if the object should be destroyed
	/// </summary>
	/// <param name="damageCount">Damage count.</param>
	public void Damage(int damageCount) {
		hp = hp - damageCount;

		if (hp <= 0) {
			// Dead!
			Destroy(gameObject);
		}
	}

	void OnTriggerEnter2D(Collider2D otherCollider) {
		// is this a shot?
		ShotScript shot = otherCollider.gameObject.GetComponent<ShotScript>();
		if (shot != null) {
			// avoid friendly fire
			if (shot.isEnemyShot != isEnemy) {
				Damage(shot.damage);

				// Destroy the shot
				// Remember to always target the game object, 
				// otherwise you will just remove the script
				Destroy(shot.gameObject);
			}
		}
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
