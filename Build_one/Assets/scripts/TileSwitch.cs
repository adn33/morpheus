using UnityEngine;
using System.Collections;

public class TileSwitch : MonoBehaviour {


	public enum TileDirection{Up, Down, Left, Right};
    public TileDirection currentDirection;

	
	public Texture up_Tex;
	public Texture left_Tex;
	public Texture right_Tex;
	public Texture down_Tex;


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
	
		//bool isValid = true;

		//do {
	   
						switch (currentDirection) {

						case(TileDirection.Up):
							
								renderer.material.SetTexture("_MainTex",up_Tex);
								currentDirection ++;
								break;
						case(TileDirection.Down):
								renderer.material.SetTexture("_MainTex",down_Tex);
								currentDirection ++;
								break;

						case(TileDirection.Left):
								renderer.material.SetTexture("_MainTex",left_Tex);
								currentDirection ++;
								break;
						case(TileDirection.Right):
								renderer.material.SetTexture("_MainTex",right_Tex);
								currentDirection ++;
				                currentDirection = 0;
								break;
						}
				//} while(isValid = true);
				
		}
		


}



		
			
		 
		
	

