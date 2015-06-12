using UnityEngine;
using System.Collections;
using System.Linq;
using System.Collections.Generic;

/// <summary>
/// Parallax scrolling script that should be assigned to a layer
/// </summary>
public class ScrollingScript : MonoBehaviour {

	/// <summary>
	/// Scrolling speed
	/// </summary>
	public Vector2 speed = new Vector2(2, 2);

	/// <summary>
	/// Moving direction
	/// </summary>
	public Vector2 direction = new Vector2(-1, 0);

	/// <summary>
	/// Should movement be applied to camera?
	/// </summary>
	public bool isLinkedToCamera = false;

	/// <summary>
	/// Background is infinite
	/// "public" to turn on "looping" in the "Inspector" view
	/// </summary>
	public bool isLooping = false;

	/// <summary>
	/// List of children with a renderer
	/// - To store the layer children
	/// </summary>
	private List<Transform> backgroundPart;

	// Use this for initialization
	//
	// Set the backgroundPart list with the children that have a renderer. 
	// Thanks to a bit of LINQ, we order them by their X position and put 
	// the leftmost at the first position of the array
	void Start () {
		// Get all the children

		// for infinite background only
		if (isLooping) {
			// get all the children of the layer with a renderer
			backgroundPart = new List<Transform>();
			for (int i = 0; i < transform.childCount; i++) {
				Transform child = transform.GetChild(i);

				// add only the visible children
				if (child.GetComponent<Renderer>() != null) {
					backgroundPart.Add(child);
				}
			}

			// sort by position
			// Note: Get the children from left to right
			// we would need to add a few conditions to handle
			// all the possible scrolling directions
			backgroundPart = backgroundPart.OrderBy(t => t.position.x).ToList();
		}
	
	}
	
	// Update is called once per frame
	//
	// If the isLooping flag is set to true, we retrieve the first child 
	// stored in the backgroundPart list. We test if it's completely outside 
	// the camera field. When it's the case, we change its position to be 
	// after the last (rightmost) child. Finally, we put it at the last position
	// of backgroundPart list
	void Update () {
		// Movement
		Vector3 movement = new Vector3 (speed.x * direction.x,
		                               speed.y * direction.y,
		                               0);

		movement *= Time.deltaTime;
		transform.Translate (movement);

		// Move the camera
		if (isLinkedToCamera) {
			Camera.main.transform.Translate(movement);
		}

		// Loop
		if (isLooping) {
			// get the first object
			// The list is ordered from left (x position) to right
			Transform firstChild = backgroundPart.FirstOrDefault();

			if (firstChild != null) {
				// Check if the child is already (partly) before the camera
				// We test the position first because the RendererExtensions.IsVisibleFrom
				// method is a bit heavier to execute
				if (firstChild.position.x < Camera.main.transform.position.x) {

					// if the child is already on the left of the camera,
					// we test if it's completely outside and needs to be
					// recycled.
					if (firstChild.GetComponent<Renderer>().IsVisibleFrom(Camera.main) == false) {
						// get the last child position
						Transform lastChild = backgroundPart.LastOrDefault();
						Vector3 lastPosition = lastChild.transform.position;
						Vector3 lastSize = (lastChild.GetComponent<Renderer>().bounds.max 
						                    - lastChild.GetComponent<Renderer>().bounds.min);

						// Set the position of the recycled one to be AFTER the last child
						// Note: Only works for horizontal scrolling currently
						firstChild.position = new Vector3(lastPosition.x + lastSize.x, 
						                                  firstChild.position.y, 
						                                  firstChild.position.z);

						// Set the recycled child to be the last position 
						// of the backgroundPart list
						backgroundPart.Remove(firstChild);
						backgroundPart.Add (firstChild);
					}

				}
			}
		}
	}
}
