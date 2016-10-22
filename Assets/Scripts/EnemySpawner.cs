using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemySpawner : MonoBehaviour {
	public Transform spawnPoint;
	public Transform Canvas;
	public GameObject enemy;
	public List<GameObject> activeEnemys;
	public int WaveLenght;
	// Use this for initialization
	void Start () {
		StartCoroutine (SpawnEnemy ());
	}
	
	IEnumerator SpawnEnemy()
	{
		CreateNewEnemy ();
		WaveLenght--;
		StartCoroutine (ResetTimer ());
		yield return null;
	}

	IEnumerator ResetTimer()
	{
		float randTime = Random.Range (0, 5.0f);
		yield return new WaitForSeconds (randTime);
		if (WaveLenght > 0) 
		{
			StartCoroutine (SpawnEnemy ());
		}
	}

	public void RestartEnemy()
	{
		
	}

	public void CreateNewEnemy()
	{
		GameObject _newEnemy = Instantiate (enemy, spawnPoint.position, spawnPoint.rotation) as GameObject;
		_newEnemy.transform.localScale = new Vector3 (1, 1, 1);
		_newEnemy.transform.SetParent (Canvas);
		activeEnemys.Add (_newEnemy);
	}
}
