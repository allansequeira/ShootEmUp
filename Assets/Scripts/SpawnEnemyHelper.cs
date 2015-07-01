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
	
	// TODO: Add randomness to x and y position when spawning enemies.
	/// <summary>
	/// Spawns the enemy at the given position
	/// </summary>
	/// <param name="position">Position.</param>
	public void SpawnEnemy(Vector3 position) {
		Vector3 pos = new Vector3(position.x + 20, position.y + 1, position.z);
		Debug.Log ("Instantiating enemy at pos: " + pos);
		instantiate (enemyPreFab, pos);
	}

	/// <summary>
	/// Spawn the specified prefab at the given position.
	/// </summary>
	/// <param name="prefab">Prefab.</param>
	/// <param name="position">Position.</param>
	public void Spawn(Transform prefab, Vector3 position) {

	}

	/// <summary>
	/// Instantiate the specified prefab at the specified position.
	/// </summary>
	/// <param name="prefab">Prefab.</param>
	/// <param name="position">Position.</param>
	/// <returns></returns>
	private void instantiate(Transform prefab, Vector3 position) {
		var enemy = Instantiate (prefab, 
		                               position, Quaternion.identity) as Transform;
		//return enemy;
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
