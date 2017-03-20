using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour {

	public static int numEnemies; 		//number of enemies on the board
	public GameObject enemy; 			//enemy prefab to be spawned
	public EnemyMoveTrigger moveTrigger;
	public GameObject spawnPoint; 		//point where enemies can spawn
	public List<Transform> spawnPoints;	//list of spawn points the enemy can spawn from
	public static List<GameObject> enemies;


	private const float SPAWNTIME = 2f;	//how long between each spawn
	private const float RADIUS = 200;	//radius of the circle of spawn points
	private const int NUMSPAWNERS = 40; //number of spawn points
	private const int MAXENEMIES = 150; //maximum number of enemies allowed
	private const float TILESKIP = 2.4f;

	void Awake(){
		enemies = new List<GameObject> ();
		spawnPoints = new List<Transform> ();

		//Make roughly NUMSPAWNERS spawners in a grid, with a space in the middle.
		int sideNum = Mathf.RoundToInt(Mathf.Sqrt(NUMSPAWNERS));
		Vector3 currentPos = new Vector3 (-RADIUS, RADIUS, 0);
		for (int i = 0; i < sideNum; i++) {
			for (int j = 0; j < sideNum; j++) {
				GameObject myObject = Instantiate (spawnPoint, currentPos, Quaternion.identity);
				spawnPoints.Add (myObject.transform);
				currentPos += new Vector3 (TILESKIP * RADIUS/sideNum, 0, 0);
			}
			currentPos = new Vector3 (-RADIUS, currentPos.y - (TILESKIP * RADIUS/sideNum), 0);
		}
			

		//Makes a NUMSPAWNERS spawners in two concentric circles around the origin
/*		for (int i = 0; i < NUMSPAWNERS; i++) {
			float angle = i * Mathf.PI * 2 / NUMSPAWNERS;
			Vector3 pos = new Vector3 (Mathf.Cos (angle), Mathf.Sin (angle), 0) * RADIUS;
			GameObject myObject = Instantiate (spawnPoint, pos, Quaternion.identity);
			spawnPoints.Add (myObject.transform);
			myObject = Instantiate (spawnPoint, pos / 2, Quaternion.identity);
			spawnPoints.Add (myObject.transform);
		}
*/
	}

	// Use this for initialization
	void Start () {
		foreach (Transform loc in spawnPoints) {
			Spawn (loc);
		}
		InvokeRepeating ("SpawnRandom", SPAWNTIME, SPAWNTIME);
	}
	
	void SpawnRandom (){
		if (numEnemies < MAXENEMIES) {
			int spawnPointIndex = Random.Range (0, spawnPoints.Count);
			Instantiate(moveTrigger, spawnPoints[spawnPointIndex].position, spawnPoints [spawnPointIndex].rotation);
			GameObject myObject = Instantiate (enemy, spawnPoints [spawnPointIndex].position, spawnPoints [spawnPointIndex].rotation);
			enemies.Add (myObject);

		}
	}

	void Spawn (Transform loc){
		Instantiate(moveTrigger, loc.position, loc.rotation);
		GameObject myObject = Instantiate (enemy, loc.position, loc.rotation);
		enemies.Add (myObject);
	}

	public static List<GameObject> GetEnemies(){
		return enemies;
	}
}
