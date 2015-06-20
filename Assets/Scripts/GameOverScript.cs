using UnityEngine;
using System.Collections;

/// <summary>
/// Script to start or quit the game when the player dies
/// </summary>
public class GameOverScript : MonoBehaviour {

	void OnGUI() {
		const int buttonWidth = 120;
		const int buttonHeight = 60;

		// center in X, 1/3 of the height in Y
		Rect retryButton = new Rect (
							Screen.width / 2 - (buttonWidth / 2),
							(1 * Screen.height / 3) - (buttonHeight / 2),
							buttonWidth,
							buttonHeight
							);

		if (GUI.Button (retryButton, "Retry")) {
			// reload the level
			Application.LoadLevel("Stage1");
		}

		// center in X, 1/3 of the height in Y
		Rect backToMenuButton = new Rect (
									Screen.width / 2 - (buttonWidth / 2),
									(2 * Screen.height / 3) - (buttonHeight / 2),
									buttonWidth,
									buttonHeight
								);
		if (GUI.Button (backToMenuButton, "Back to menu")) {
			// reload the level
			Application.LoadLevel("Menu");
		}

	}


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
