using UnityEngine;
using System.Collections;

public class MonsterDoor : Door {

	override public Vector3 getOffset() {
		return new Vector3 (0, 1, 1);
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
