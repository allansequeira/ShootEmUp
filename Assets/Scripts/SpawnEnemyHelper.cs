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
	
	/// <summary>
	/// Spawns the enemy at the given position
	/// </summary>
	/// <param name="position">Position.</param>
	public void SpawnEnemy(Vector3 position) {
		Debug.Log ("Instantiating enemy at pos: " + position);
		instantiate (enemyPreFab, position);
	}

	/// <summary>
	/// Spawns the enemy at a random position relative to the camera (position)
	/// </summary>
	public void SpawnEnemy() {
		Vector3 cameraPos = Camera.main.transform.position;
		Debug.Log ("Camera pos: " + cameraPos);
		Vector3 pos = new Vector3 (cameraPos.x + Random.Range(20, 30), cameraPos.y + Random.Range(-5, 5), 0); 
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
		// Invoke SpawnEnemy starting in 2 seconds and repeat every 2.5 seconds thereafter
		InvokeRepeating ("SpawnEnemy", 2f, 2.5f);	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
