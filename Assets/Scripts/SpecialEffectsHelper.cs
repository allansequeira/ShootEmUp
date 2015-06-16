using UnityEngine;
using System.Collections;

/// <summary>
/// Create instance of particles
/// </summary>
public class SpecialEffectsHelper : MonoBehaviour {

	/// <summary>
	/// Singleton instance.
	/// Access from everywhere using SpecialEffectsHelper.Instance
	/// </summary>
	public static SpecialEffectsHelper Instance;

	public ParticleSystem smokeEffect;
	public ParticleSystem fireEffect;

	void Awake() {
		// Register the singleton
		if (Instance != null) {
			Debug.LogError("Multiple instances of SpecialEffectsHelper");
		}

		Instance = this;
	}

	/// <summary>
	/// Create an explosion at the specified position.
	/// </summary>
	/// <param name="position">Position.</param>
	public void Explosion(Vector3 position) {
		// instantiate smoke
		instantiate (smokeEffect, position);

		// where there is smoke, there is fire
		instantiate (fireEffect, position);

	}

	/// <summary>
	/// Instantiate a Particle system from the prefab at the given position
	/// </summary>
	/// <param name="prefab">Prefab.</param>
	/// <param name="position">Position.</param>
	/// <returns></returns>
	private ParticleSystem instantiate(ParticleSystem prefab, Vector3 position) {
		ParticleSystem particleSystem = Instantiate (prefab, 
		                                            position, 
		                                            Quaternion.identity) as ParticleSystem;

		// Make sure it will be destroyed
		Destroy (particleSystem.gameObject, particleSystem.startLifetime);

		return particleSystem;
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
