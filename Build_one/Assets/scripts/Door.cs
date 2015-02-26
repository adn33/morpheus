using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour
{
	private Tile tile;
	public Tile nextToTile
	{
		get { return tile; }
		set {
			tile = value;
			reposition();
		}
	}

	virtual public Vector3 getOffset() {
		return Vector3.zero;
	}

	public void reposition()
	{
		Debug.Log ("Position before: " + this.transform.position);
		transform.parent = tile.transform;
		transform.localPosition = getOffset(); 
		Debug.Log ("Position after: " + this.transform.position);
	}

//	dreamdoor = ((GameObject)Instantiate(DreamDoorPrefab, new Vector3(2 - Mathf.Floor(doorSize/2),1f, -6 + Mathf.Floor(doorSize/2)), Quaternion.Euler(new Vector3()))).GetComponent<DreamDoor>();
//	monsterdoor = ((GameObject)Instantiate(MonsterDoorPrefab, new Vector3(5 - Mathf.Floor(doorSize/2),1f, -6 + Mathf.Floor(doorSize/2)), Quaternion.Euler(new Vector3()))).GetComponent<MonsterDoor>();

	// Use this for initialization
	void Start ()
	{
			
	}
		
	// Update is called once per frame
	void Update ()
	{
			
	}
		
	void OnMouseEnter ()
	{
		transform.renderer.material.color = Color.blue;
		
		
	}
	
	void OnMouseExit ()
	{
		transform.renderer.material.color = Color.white;
	}
		
	void OnMouseDown ()
	{
			
		//GameManager.instance.moveCurrentPlayer (this);
	}
		
}


