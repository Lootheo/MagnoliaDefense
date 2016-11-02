using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour {
	public Text enemies, waves, gold;
	public Transform spawnPoint;
	public Transform Canvas;
	public GameObject[] enemy;
	public List<GameObject> activeEnemys;
	public int WaveLenght;
	public int Waves;
	public float enemyTime;
	public float waveTime;
	public int DefeatedEnemies = 0;
	public int currentWave = 1;
	public int currGold;
	public PrincessInfo _info;
	// Use this for initialization
	void Start () {
		_info = DataPrincess.Load ();
		DataSender _sender = GameObject.FindObjectOfType<DataSender>();
		if (_sender != null) {
			WaveLenght = _sender._enemysWave;
			Waves = _sender._waves;
			enemyTime = _sender._enemyTime;
			waveTime = _sender._waveTime;
		} else 
		{
			WaveLenght = 5;
			Waves = 3;
			enemyTime = 1;
			waveTime = 20;
		}
		gold.text = "0";
		enemies.text = DefeatedEnemies + "/" + WaveLenght;
		waves.text = currentWave + "/" + Waves;
		StartCoroutine (SpawnEnemy ());
	}
	
	IEnumerator SpawnEnemy()
	{
		for (int i = 0; i < WaveLenght; i++) 
		{
			CreateNewEnemy ();
			float _wait = Random.Range (3.0f, 5.0f);
			yield return new WaitForSeconds(_wait);
//			yield return new WaitForSeconds(enemyTime);
		}
	}

	public void DestroyEnemy()
	{
		DefeatedEnemies++;
		currGold += 10;
		gold.text = currGold.ToString ();
		enemies.text = DefeatedEnemies + "/" + WaveLenght;
		if (DefeatedEnemies == WaveLenght) 
		{
			if (currentWave < Waves-1) {
				StartNextWave ();
			} else 
			{
				Debug.Log ("Go to next level");
				Debug.Log ("Tu oro ganado fue de " + currGold);
				_info.gold += currGold;
				Debug.Log ("Tu oro total es de " + _info.gold);
				DataPrincess.Save (_info);
			}
		}
	}

	public void StartNextWave()
	{
		DefeatedEnemies = 0;
		enemies.text = DefeatedEnemies + "/" + WaveLenght;
		currentWave++;
		waves.text = (currentWave+1) + "/" + Waves;
		StartCoroutine (SpawnEnemy ());
	}

	public void RestartEnemy()
	{
		
	}

	public void CreateNewEnemy()
	{
		int Rand = Random.Range (0, enemy.Length);
		GameObject _newEnemy = Instantiate (enemy[Rand], spawnPoint.position, spawnPoint.rotation) as GameObject;
		EnemyScript ES = _newEnemy.GetComponent<EnemyScript> ();
		ES.ES = this;
		_newEnemy.transform.localScale = new Vector3 (1, 1, 1);
		_newEnemy.transform.SetParent (Canvas);
		activeEnemys.Add (_newEnemy);
	}
}
