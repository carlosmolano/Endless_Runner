using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

    public static LevelManager Instance { set; get; }

    //List of pieces

    public List<GameObject> tiles = new List<GameObject>();
    private Transform playerTransform;
	private float SpawnZ = 0.0f;
	private float tileLength = 5.9f;
	private int amnTiles = 20;
	private float safeZone = 15.0f;
	private int lastTileIndex = 0;

	private List<GameObject> activeTiles;

    void Start(){
		activeTiles = new List<GameObject>();
		playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
		for (int i = 0; i < amnTiles; i++){
			if(i < 2){
				SpawnTile(0);
			}else{
				SpawnTile();
			}
		}
    }

	void Update()
	{
		if(playerTransform.position.z - safeZone > (SpawnZ - amnTiles * tileLength)){
			SpawnTile();
			DeleteTile();
		}
	}

	void SpawnTile(int prefabIndex = -1){
		GameObject go;
		if(prefabIndex == -1){
			go = Instantiate(tiles[RandomTileIndex()]) as GameObject;
           
		}else{
			go = Instantiate(tiles[prefabIndex]) as GameObject;
		}
		go.transform.SetParent(transform);
        go.transform.position = Vector3.forward * SpawnZ;
        SpawnZ += tileLength;
        activeTiles.Add(go);
	}

	void DeleteTile(){
		Destroy(activeTiles[0]);
		activeTiles.RemoveAt(0);
	}

	private int RandomTileIndex(){
		if(tiles.Count <= 1){
			return 0;
		}
		int randomIndex = lastTileIndex;
		while(randomIndex == lastTileIndex){
			randomIndex = Random.Range(0, tiles.Count);
		}
		lastTileIndex = randomIndex;
		return randomIndex;
	}
}
