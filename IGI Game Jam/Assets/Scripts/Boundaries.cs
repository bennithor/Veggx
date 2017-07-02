using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boundaries : MonoBehaviour {

	public Transform WestWall;
	public Transform EastWall;
	public Transform NorthWall;
	public Transform SouthWall;

	Vector3 StageDimensions;
	Vector3 HorizontalWallSize;
	Vector3 VerticalWallSize;

	//Vector2 PreviousScreen;
	//Vector2 CurrentScreen;

	// Use this for initialization
	void Start () {
		StageDimensions = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height,0));
		//PreviousScreen = new Vector2 (0,0);
	}

	// Update is called once per frame
	void Update () {
		//CurrentScreen = new Vector2 (Screen.width, Screen.height);

		//if (PreviousScreen.x != CurrentScreen.x || PreviousScreen.y != CurrentScreen.y) {
			StageDimensions = Camera.main.ScreenToWorldPoint (new Vector3 (Screen.width, Screen.height, 0));
			HorizontalWallSize = new Vector3 (2, StageDimensions.y * 2, 0);
			VerticalWallSize = new Vector3 (StageDimensions.x * 2, 2, 0);

			// Position walls
			WestWall.position = new Vector3 (-StageDimensions.x, 0, 0);
			EastWall.position = new Vector3 (StageDimensions.x, 0, 0);
			NorthWall.position = new Vector3 (0, StageDimensions.y, 0);
			SouthWall.position = new Vector3 (0, -StageDimensions.y, 0);

			// Scale walls
			WestWall.GetComponent<BoxCollider2D> ().size = HorizontalWallSize;
			EastWall.GetComponent<BoxCollider2D> ().size = HorizontalWallSize;
			NorthWall.GetComponent<BoxCollider2D> ().size = VerticalWallSize;
			SouthWall.GetComponent<BoxCollider2D> ().size = VerticalWallSize;
		//}

		//PreviousScreen = new Vector2 (Screen.width,Screen.height);
	}
}
