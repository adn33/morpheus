﻿using UnityEngine;
using System.Collections;

public class Door : Tile {




		
		//public Vector2 gridPosition = Vector2.zero;
		
		// Use this for initialization
		void Start () {
			
		}
		
		// Update is called once per frame
		void Update () {
			
		}
		
		void OnMouseEnter() {
		transform.renderer.material.color = Color.blue;
		
		
	}
	
	void OnMouseExit() {
		transform.renderer.material.color = Color.white;
	}
	
 
		
		void OnMouseDown() {
			
			GameManager.instance.moveCurrentPlayer(this);
		}
		
	}


