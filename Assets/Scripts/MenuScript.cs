using UnityEngine;
using System.Collections;

/// <summary>
/// Title screen script.
/// </summary>
public class MenuScript : MonoBehaviour {


	void OnGUI() {
		const int buttonWidth = 84;
		const int buttonHeight = 60;

		// Determine the button's placement on screen
		// center in X, 2/3 of the height in Y
		Rect buttonRect = new Rect (Screen.width / 2 - (buttonWidth / 2),
		                           (2 * Screen.height / 3) - (buttonHeight / 2),
		                           buttonWidth,
		                           buttonHeight);

		// Draw a button to start the game
		if (GUI.Button (buttonRect, "Start")) {
			// On click, load the first level.
			// "Stage1" is the name of the first scene we created
			Application.LoadLevel("Stage1");
		}
	}


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
