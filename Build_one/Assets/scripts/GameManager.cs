using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {
	public static GameManager instance;

	public GameObject DreamDoorPrefab;
	public GameObject MonsterDoorPrefab;
	public GameObject TilePrefab;
	public GameObject UserPlayerPrefab;
	public GameObject AIPlayerPrefab;

	public int five = 0;


	public bool Moveable = false;
	
	public int mapSize = 0;
	private int doorSize = 6;

	List <List<Tile>> map = new List<List<Tile>>();
	List <Player> players = new List<Player>();
	List <DreamDoor> dreamdoors = new List<DreamDoor>();
    List <MonsterDoor> monsterdoors = new List<MonsterDoor>();
	int currentPlayerIndex = 0;
	
	void Awake() {
		instance = this;
	}
	
	// Use this for initialization
	void Start () {		
		generateMap();
		generatePlayers();
		generateDoor ();
	}
	
	// Update is called once per frame
	void Update () {
		
		players[currentPlayerIndex].TurnUpdate();
	}
	
	public void nextTurn() {
		if (currentPlayerIndex + 1 < players.Count) {
			currentPlayerIndex++;
		} else {
			currentPlayerIndex = 0;
		}
	}



	public void moveCurrentPlayer(Tile destTile) {
				

		   players [currentPlayerIndex].moveDestination = destTile.transform.position + 1.5f * Vector3.up;
				
		}



   void generateMap() {
		map = new List<List<Tile>>();
		for (int i = 0; i < mapSize; i++) {
			List <Tile> row = new List<Tile>();
			for (int j = 0; j < mapSize; j++) {
				Tile tile = ((GameObject)Instantiate(TilePrefab, new Vector3(i - Mathf.Floor(mapSize/2),0, -j + Mathf.Floor(mapSize/2)), Quaternion.Euler(new Vector3()))).GetComponent<Tile>();
				tile.gridPosition = new Vector2(i, j);
				row.Add (tile);
			}
			map.Add(row);
		   }
		}

	void generateDoor() {

		DreamDoor dreamdoor;
		
		dreamdoor = ((GameObject)Instantiate(DreamDoorPrefab, new Vector3(5 - Mathf.Floor(doorSize/2),1f, -0 + Mathf.Floor(doorSize/2)), Quaternion.Euler(new Vector3()))).GetComponent<DreamDoor>();
		
		dreamdoors.Add(dreamdoor);

		MonsterDoor monsterdoor;
		
		monsterdoor = ((GameObject)Instantiate(MonsterDoorPrefab, new Vector3(2 - Mathf.Floor(doorSize/2),1f, -6 + Mathf.Floor(doorSize/2)), Quaternion.Euler(new Vector3()))).GetComponent<MonsterDoor>();
		
		monsterdoors.Add(monsterdoor);


	}


	
	void generatePlayers() {
		UserPlayer player;

		
		player = ((GameObject)Instantiate(UserPlayerPrefab, new Vector3(0 - Mathf.Floor(mapSize/1),1f, -0 + Mathf.Floor(mapSize/2)), Quaternion.Euler(new Vector3()))).GetComponent<UserPlayer>();
		
		players.Add(player);





	}
}
