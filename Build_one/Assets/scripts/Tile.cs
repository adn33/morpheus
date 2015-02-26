using UnityEngine;
using System.Collections;

public class Tile : MonoBehaviour {
	
	public Vector2 gridPosition = Vector2.zero;
	
	public enum TileDirection{Up, Down, Left, Right, Empty};
	private TileDirection currDir = TileDirection.Empty;
	public TileDirection currentDirection
	{
		get { return currDir; }
		set {
			currDir = value;
			switch (currDir) {
			case(TileDirection.Up):				
				renderer.material.SetTexture("_MainTex",up_Tex);
				break;
			case(TileDirection.Down):
				renderer.material.SetTexture("_MainTex",down_Tex);
				break;
			case(TileDirection.Left):
				renderer.material.SetTexture("_MainTex",left_Tex);
				break;
			case(TileDirection.Right):
				renderer.material.SetTexture("_MainTex",right_Tex);
				break;
			case(TileDirection.Empty):
				renderer.material.SetTexture("_MainTex",default_Tex);
				break;
			}
		}
	}
	
	public Texture up_Tex;
	public Texture left_Tex;
	public Texture right_Tex;
	public Texture down_Tex;
	public Texture default_Tex;
	
	// Use this for initialization
	void Start () {
	}
	void Update(){
	}
	
	void OnMouseDown (){
		UpdateCurrentDirection();
		Debug.Log (currDir);
	}
	// Update is called once per frame
	void UpdateCurrentDirection () {
		if (currentDirection == TileDirection.Empty) {
			return; // not allowed to change direction for empty tiles
		}
		switch (currentDirection) {
		case(TileDirection.Up):
			currentDirection = TileDirection.Down;
			break;
		case(TileDirection.Down):
			currentDirection = TileDirection.Left;
			break;
		case(TileDirection.Left):
			currentDirection = TileDirection.Right;
			break;
		case(TileDirection.Right):
			currentDirection = TileDirection.Up;
			break;
		}
	}

}
