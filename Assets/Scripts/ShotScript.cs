using UnityEngine;
using System.Collections;

/// <summary>
/// Projectile behavior
/// </summary>
public class ShotScript : MonoBehaviour {

	// Designer variables

	/// <summary>
	/// Damage inflicted
	/// </summary>
	public int damage = 1;

	/// <summary>
	/// Projectile damage player or enemies
	/// </summary>
	public bool isEnemyShot = false;

	// Use this for initialization
	void Start () {
		// Destroy game object after 20 seconds to avoid leak
		Destroy (gameObject, 20);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
