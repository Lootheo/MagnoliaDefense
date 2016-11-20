using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour {
	public Text enemiesText, wavesText, gold;
	public Transform spawnPoint;
	public Transform Canvas;
	public GameObject[] enemy;
	public List<GameObject> activeEnemys;
	public int DefeatedEnemies = 0;
	public EnemyCreatorScript.Wave currentWave;
	public int waveNumber;
	public PrincessInfo _info;
	public EnemyType enemyType;
	public int totalLevelEnemies =0;


	EnemyCreatorScript.Level currentLevel;
	EnemyCreatorScript.GameLevels gameLevels;
	// Use this for initialization
	void Start () {
		_info = DataPrincess.Load ();
		gameLevels = DataPrincess.LoadGameLevels ();
		DataSender _sender = GameObject.FindObjectOfType<DataSender>();
		if (_sender != null) {
			currentLevel = gameLevels.FindLevel (_sender.level);
			Debug.Log ("Loading Level: " + _sender.level.ToString ());
		} else {
			currentLevel = gameLevels.FindLevel (1);
		}

		wavesText.text = waveNumber + "/" + currentLevel.numberOfWaves;

		SpawnLevel (currentLevel);
	}
	/// <summary>
	/// Spawns the level.
	/// </summary>
	/// <param name="levelToSpawn">Current level.</param>
	public void SpawnLevel(EnemyCreatorScript.Level levelToSpawn){
		
		float waveTime =0;
		for (int i=1;i<=levelToSpawn.numberOfWaves;i++){
			currentWave = levelToSpawn.FindWave (i);
			totalLevelEnemies += currentWave.enemies.Count;
			Debug.Log ("Wave: " +  currentWave.waveNumber);
			StartCoroutine (SpawnWave (currentWave,waveTime));
			waveTime += currentWave.enemies [currentWave.enemies.Count - 1].timeOfSpawn + 10.0f;
		}


	}

	/// <summary>
	/// Spawns all the enemies of a wave
	/// </summary>
	/// <param name="waveToSpawn">Wave to spawn.</param>
	IEnumerator SpawnWave(EnemyCreatorScript.Wave waveToSpawn,float _timeToSpawn){
		yield return new WaitForSeconds (_timeToSpawn);

		wavesText.text = waveToSpawn.waveNumber + "/" + currentLevel.numberOfWaves;
		enemiesText.text = totalLevelEnemies.ToString ();
		foreach (EnemyCreatorScript.Enemy enemy in waveToSpawn.enemies) {
			Debug.Log ("Enemy: " + enemy.timeOfSpawn.ToString());
			StartCoroutine (SpawnEnemy (enemy.timeOfSpawn,enemy.enemyType));
		}
		Debug.Log (currentWave.enemies[currentWave.enemies.Count-1].timeOfSpawn.ToString());
	}

	/// <summary>
	/// Spawns the enemy based on GameLevels Info, needs improvement from instantiated time to fixed one
	/// </summary>
	/// <returns>The enemy.</returns>
	IEnumerator SpawnEnemy(float _timeOfSpawn, EnemyType _enemyType)
	{
		yield return new WaitForSeconds (_timeOfSpawn);
		CreateNewEnemy (_enemyType);
	}

	public void DestroyEnemy(){
		totalLevelEnemies--;
		enemiesText.text = totalLevelEnemies.ToString ();
		Debug.Log ("Calling destroy" + totalLevelEnemies.ToString());
		if (totalLevelEnemies == 0) {
			if (_info.unlockedLevels == currentLevel.levelNumber) {
				_info.unlockedLevels++;
			}
			DataPrincess.Save (_info);
			SceneManager.LoadScene ("VictoryLevel");
		}
	}

	/// <summary>
	/// Creates an enemy based on the enemytype input
	/// </summary>
	/// <param name="_enemyType">The type of the enemy</param>
	public void CreateNewEnemy(EnemyType _enemyType)
	{
		GameObject _newEnemy = Instantiate (enemy[(int)_enemyType], spawnPoint.position, spawnPoint.rotation) as GameObject;
		EnemyScript ES = _newEnemy.GetComponent<EnemyScript> ();
		ES.ES = this;
		ES.speed = GamePropertiesScript.GetEnemySpeed (_enemyType);
		_newEnemy.transform.localScale = new Vector3 (1, 1, 1);
		_newEnemy.transform.SetParent (Canvas);
		activeEnemys.Add (_newEnemy);
	}
}
