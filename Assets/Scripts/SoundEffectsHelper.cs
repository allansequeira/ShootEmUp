using UnityEngine;
using System.Collections;

/// <summary>
/// Create instances of sound
/// </summary>
public class SoundEffectsHelper : MonoBehaviour {

	/// <summary>
	/// Singleton instance.
	/// Access from everywhere using SoundEffectsHelper.Instance
	/// </summary>
	public static SoundEffectsHelper Instance;

	public AudioClip explosionSound;
	public AudioClip playerShotSound;
	public AudioClip enemyShotSound;

	void Awake() {
		// Register the singleton
		if (Instance != null) {
			Debug.LogError("Multiple instances of SoundEffectsHelper");
		}

		Instance = this;
	}

	public void MakeExplosionSound() {
		MakeSound (explosionSound);
	}

	public void MakePlayerShotSound() {
		MakeSound (playerShotSound);
	}

	public void MakeEnemyShotSound() {
		MakeSound (enemyShotSound);
	}

	/// <summary>
	/// Play a given sound
	/// </summary>
	/// <param name="audioClip">Audio clip.</param>
	private void MakeSound(AudioClip audioClip) {
		// As it's not 3D audio clip, position doesn't matter
		AudioSource.PlayClipAtPoint (audioClip, transform.position);
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
