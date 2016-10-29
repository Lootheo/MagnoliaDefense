using UnityEngine;
using System.Collections;

public class EnemySpawnScript : MonoBehaviour {

	public Object enemy;
	public Transform spawnPoint;
	public float spawnTime = 3.0f;
	// Use this for initialization
	void Start () {
		StartCoroutine (SpawnCoroutine ());
	
	}


	IEnumerator SpawnCoroutine(){
		while (true) {
			Instantiate (enemy, spawnPoint.position, Quaternion.identity);
			yield return new WaitForSeconds (spawnTime);
		}

	}

	// Update is called once per frame
	void Update () {
	
	}
}
