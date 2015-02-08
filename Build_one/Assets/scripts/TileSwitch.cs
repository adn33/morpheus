using UnityEngine;
using System.Collections;

public class TileSwitch : MonoBehaviour {


	public enum TileDirection{Up, Down, Left, Right};
    public TileDirection currentDirection;
	
	Texture2D tex = Resources.Load("forward_tex.jpg") as Texture2D;

			

	// Use this for initialization
	void Start () {

	}
	void Update(){

	}


	void OnMouseDown (){
		UpdateCurrentDirection();
	}
	// Update is called once per frame
	void UpdateCurrentDirection () {
	
		bool isValid = true;

		do {
	   
						switch (currentDirection) {
			
						case(TileDirection.Up):
				        transform.renderer.material.mainTexture = tex;
								currentDirection ++;
								break;
						case(TileDirection.Down):
								transform.renderer.material.color = Color.green;
								currentDirection ++;
								break;

						case(TileDirection.Left):
								transform.renderer.material.color = Color.cyan;
								currentDirection ++;
								break;
						case(TileDirection.Right):
								transform.renderer.material.color = Color.magenta;
								currentDirection ++;
				                currentDirection = 0;
								break;
						}
				} while(isValid != true);
				
		}
		


}



		
			
		 
		
	

