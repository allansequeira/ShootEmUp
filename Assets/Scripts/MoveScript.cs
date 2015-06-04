using UnityEngine;
using System.Collections;

/// <summary>
/// Move the current game object
/// </summary>
public class MoveScript : MonoBehaviour {

	// Desginer variables

	/// <summary>
	/// Object speed.
	/// </summary>
	public Vector2 speed = new Vector2(10, 10);

	/// <summary>
	/// Moving direction.
	/// </summary>
	public Vector2 direction = new Vector2(-1, 0);

	private Vector2 movement;
	private Rigidbody2D rigidBodyComponent;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		// Movement
		movement = new Vector2 (speed.x * direction.x, 
		                        speed.y * direction.y);
	}

	void FixedUpdate() {
		// Apply movement to the rigidbody
		if (rigidBodyComponent == null) {
			rigidBodyComponent = GetComponent<Rigidbody2D>();
		}

		rigidBodyComponent.velocity = movement;
	}
}
