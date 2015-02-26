using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {
	public static GameManager instance;

	public GameObject DreamPrefab;
	public GameObject MonsterPrefab;
	public GameObject DreamDoorPrefab;
	public GameObject MonsterDoorPrefab;
	public GameObject TilePrefab;
	public GameObject UserPlayerPrefab;
	public GameObject AIPlayerPrefab;

	private int noOfEmpties = 7;
	public int mapSize = 0;
	private int doorSize = 6;

	List <List<Tile>> map = new List<List<Tile>>();
	List <Player> players = new List<Player>();
	List <DreamDoor> dreamdoors = new List<DreamDoor>();
    List <MonsterDoor> monsterdoors = new List<MonsterDoor>();

	//List <Dream_Player> dreams = new List<Dream_Player>();
	//List <Monster_Player> monsters = new List<Monster_Player>();
	int currentPlayerIndex = 0;
	
	void Awake() {
		instance = this;
	}
	
	// Use this for initialization
	void Start () {		
		generateMap();
		generateDoor ();
		repositionDoors ();
		// generatePlayers();
	}
	
	// Update is called once per frame
	void Update () {
//		players[currentPlayerIndex].TurnUpdate();
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
				Tile tile = ((GameObject)Instantiate(TilePrefab)).GetComponent<Tile>();
				tile.transform.position = new Vector3(i - Mathf.Floor(mapSize/2),0, -j + Mathf.Floor(mapSize/2));
				tile.gridPosition = new Vector2(i, j);
				row.Add (tile);
				assignTileDir(tile);
			}
			map.Add(row);
		   }
		}

	void assignTileDir(Tile tile) {
		// TODO: method for generating the map or a pre-made map
		Tile.TileDirection dir;
		// TODO: check if it's a corner tile and do not use empties for those
		bool corner = false;
		if (noOfEmpties > 0 && ! corner) {
			int dirInt = Random.Range (0, 10);
			if (dirInt > 4) {
				dirInt = 4;
			}
			dir = (Tile.TileDirection) dirInt;
			if (dir == Tile.TileDirection.Empty) {
				noOfEmpties--;
			}
		} else {
			dir = (Tile.TileDirection)Random.Range (0, 3);
		}
		tile.currentDirection = dir;
	}

	void generateDoor() {
		DreamDoor dreamdoor;
		dreamdoor = ((GameObject)Instantiate(DreamDoorPrefab)).GetComponent<DreamDoor>();
		dreamdoors.Add(dreamdoor);
		MonsterDoor monsterdoor;		
		monsterdoor = ((GameObject)Instantiate(MonsterDoorPrefab)).GetComponent<MonsterDoor>();
		monsterdoors.Add(monsterdoor);
	}

	void repositionDoors()
	{
		foreach (Door door in dreamdoors) { // X = 4
			door.nextToTile = map[4][Random.Range (0,4)];
		}
		foreach (Door door in monsterdoors) { // Y = 0
			door.nextToTile = map[Random.Range (0,4)][0];
		}
	}

	void generatePlayers() {
		//UserPlayer player;

		Dream_Player dream;

		Monster_Player monster;
		
		//player = ((GameObject)Instantiate(UserPlayerPrefab, new Vector3(0 - Mathf.Floor(mapSize/1),1f, -0 + Mathf.Floor(mapSize/2)), Quaternion.Euler(new Vector3()))).GetComponent<UserPlayer>();
		
		//players.Add(player);



		dream = ((GameObject)Instantiate(DreamPrefab)).GetComponent<Dream_Player>();
		players.Add(dream);
		monster = ((GameObject)Instantiate(MonsterPrefab, new Vector3(0 - Mathf.Floor(mapSize/1),1f, -1 + Mathf.Floor(mapSize/2)), Quaternion.Euler(new Vector3()))).GetComponent<Monster_Player>();
		players.Add(monster);
		dream = ((GameObject)Instantiate(DreamPrefab, new Vector3(0 - Mathf.Floor(mapSize/1),1f, -3 + Mathf.Floor(mapSize/2)), Quaternion.Euler(new Vector3()))).GetComponent<Dream_Player>();
		players.Add(dream);
		monster = ((GameObject)Instantiate(MonsterPrefab, new Vector3(0 - Mathf.Floor(mapSize/1),1f, -2 + Mathf.Floor(mapSize/2)), Quaternion.Euler(new Vector3()))).GetComponent<Monster_Player>();
		players.Add(monster);
		//positionPlayers (players);
	}
}
