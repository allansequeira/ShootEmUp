using UnityEngine;
using System.Collections;

/// <summary>
/// Helper class to spawn enemies
/// </summary>
public class SpawnEnemyHelper : MonoBehaviour {

	/// <summary>
	/// Singleton instance.
	/// Access from everywhere using SpawnEnemyHelper.Instance
	/// </summary>
	public static SpawnEnemyHelper Instance;

	/// <summary>
	/// Enemy prefab
	/// </summary>
	public Transform enemyPreFab;

	void Awake() {
		// Register the singleton
		if (Instance != null) {
			Debug.LogError("Multiple instances of SpawnEnemyHelper");
		}
		
		Instance = this;
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
