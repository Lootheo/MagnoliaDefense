using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using System.Collections.Generic;

public class EnemyCreatorScript : MonoBehaviour {
	[Serializable]
	public class GameLevels{	
		public List<Level> gameLevels;

		public void AddLevel (Level newLevel){
			if (gameLevels == null) {
				gameLevels = new List<Level> ();
			}
			foreach (Level level in gameLevels) {
				if (newLevel.levelNumber == level.levelNumber) {
					Debug.Log ("Replaced Level: " + level.levelNumber.ToString ());
					gameLevels.Remove (level);
					break;
				}
			}
			gameLevels.Add (newLevel);
		}

		public Level FindLevel (int levelNumber){
			foreach (Level level in gameLevels) {
				if (levelNumber == level.levelNumber) {
					Debug.Log ("Obtained Level: " + levelNumber);
					return level;
				}
			}
			return new Level ();
		}

		public GameLevels(){
			gameLevels = new List<Level>();
		}
	}
	[Serializable]
	public class Level{
		public List<Wave> waves;
		public int levelNumber;
		public int numberOfWaves;


		//Removes a wave if it shares the same wave number, if there is none, it only adds the new wave
		public void AddWave (Wave newWave){
			if (waves == null) {
				waves = new List<Wave> ();
			}
			foreach (Wave wave in waves) {
				if (wave.waveNumber == newWave.waveNumber) {
					Debug.Log ("Replaced Wave: " + wave.waveNumber.ToString ());
					waves.Remove (wave);
					break;
				}
			}
			waves.Add (newWave);
		}

		public Wave FindWave (int waveNumber){
			foreach (Wave wave in waves) {
				if (waveNumber == wave.waveNumber) {
					Debug.Log ("Obtained Wave: " + levelNumber);
					return wave;
				}
			}
			return null;
		}

	}
	[Serializable]
	//Class that contains the enemies with their time of spawn
	public class Wave{
		public List<Enemy> enemies;
		public int waveNumber;

		public Wave(){
			enemies = new List<Enemy>();
		}

		public Wave(int _waveNumber){
			enemies = new List<Enemy>();
			waveNumber = _waveNumber;
		}
	}
	[Serializable]
	//Class that contains the type of enemy and their respective time of spawn
	public class Enemy{
		public EnemyType enemyType;
		public float timeOfSpawn;

		public Enemy (EnemyType _enemyType, float _timeOfSpawn){
			enemyType = _enemyType;
			timeOfSpawn = _timeOfSpawn;
		}
	}



	//Integer variable of wave properties
	int numberOfWaves;
	int currentLevel;
	int currentWave;

	public InputField numberOfWavesInput;
	public InputField levelInput;
	public InputField waveInput;

	public Button startButton;
	public Button stopButton;

	public Button enemy1Button;
	public Button enemy2Button;
	public Button enemy3Button;
	public Button enemy4Button;

	public Text timeElapsedText;
	public float timeElapsed=0.0f;
	public Text enemiesCreatedText;

	public Transform spawnPoint;
	public Transform flyingSpawnPoint;

	public UnityEngine.Object[] enemy;

	List <GameObject> enemyList;

	bool playing;

	//The wave and level
	Level newLevel;
	Wave newWave;
	GameLevels gameLevels;

	//Add all the button and input listeners
	void Start(){
		enemyList = new List<GameObject> ();

		enemy1Button.onClick.AddListener (() => SpawnEnemy (EnemyType.Normal));
		enemy2Button.onClick.AddListener (() => SpawnEnemy (EnemyType.Fast));
		enemy3Button.onClick.AddListener (() => SpawnEnemy (EnemyType.Brute));
		enemy4Button.onClick.AddListener (() => SpawnEnemy (EnemyType.FlyingNormal));

		startButton.onClick.AddListener (() => StartWave ());
		stopButton.onClick.AddListener (() => StopWave ());

		waveInput.text = "1";
		numberOfWavesInput.text = "1";
		levelInput.text = "1";

		gameLevels = DataPrincess.LoadGameLevels ();


		ReadGameLevels (gameLevels);


	}


	public void StartWave(){
		
		Debug.Log ("Empezando oleada");
		currentWave = int.Parse(waveInput.text);
		numberOfWaves = int.Parse(numberOfWavesInput.text);
		currentLevel =  int.Parse(levelInput.text);
		Debug.Log ("Starting Wave: " + currentWave);
		Debug.Log ("Current Level: " + currentLevel);
		Debug.Log ("Number Of Waves: " + numberOfWaves);

		//Create a new wave for the level
		newWave = new Wave ();
		newWave.waveNumber = currentWave;
		//Get a level with the level number in the game levels, if there is none, create the level
		newLevel = gameLevels.FindLevel (currentLevel);
		newLevel.levelNumber = currentLevel;
		newLevel.numberOfWaves = numberOfWaves;


		timeElapsed = 0.0f;
		timeElapsedText.text = "0";
		playing = true;
		StartCoroutine (TimeFunction ());


	}
		
	IEnumerator TimeFunction(){
		while (playing) {
			yield return new WaitForSeconds (0.1f);
			timeElapsed += 0.1f;
			timeElapsed = (float)System.Math.Round ((double)timeElapsed, 2);
			timeElapsedText.text = timeElapsed.ToString ();
		}
	}

	public void StopWave(){
		Debug.Log ("Terminando oleada");
		playing = false;

		foreach (Enemy enemy in newWave.enemies) {
			Debug.Log ("Enemy in time: " + enemy.timeOfSpawn);
		}

		newLevel.AddWave (newWave);
		gameLevels.AddLevel (newLevel);
		Debug.Log ("Saving game level data :" + newLevel.levelNumber);
		DataPrincess.Save (gameLevels);
	}

	public void ReadGameLevels(GameLevels _gameLevels){
		foreach (Level level in _gameLevels.gameLevels) {
			Debug.Log ("Level Number: " + level.levelNumber);
			foreach (Wave wave in level.waves) {
				Debug.Log ("Wave Number:  " + wave.waveNumber);
			}
		}

	}

	public void SpawnEnemy(EnemyType enemyType){
		if (playing) {
			CreateNewEnemy (enemyType);
			enemiesCreatedText.text = (int.Parse (enemiesCreatedText.text) + 1).ToString ();
			newWave.enemies.Add (new Enemy (enemyType, timeElapsed));
		}
	}

	public void CreateNewEnemy(EnemyType enemyType)
	{
		GameObject newEnemy;
		if(enemyType != EnemyType.FlyingNormal)
			newEnemy = Instantiate (enemy[(int)enemyType], spawnPoint.position, spawnPoint.rotation) as GameObject;
		else
			newEnemy = Instantiate (enemy[(int)enemyType], flyingSpawnPoint.position, flyingSpawnPoint.rotation) as GameObject;
		Destroy(newEnemy.GetComponent<EnemyScript> ());
		DumbEnemyScript DES = newEnemy.AddComponent<DumbEnemyScript> ();
		DES.speed = GetEnemySpeed (enemyType);
		newEnemy.transform.localScale = new Vector3 (1, 1, 1);
		enemyList.Add (newEnemy);
	}

	public static float GetEnemySpeed (EnemyType enemyType){
		switch (enemyType) {
		case EnemyType.Normal:
			return GamePropertiesScript.normalEnemySpeed;
			break;
		case EnemyType.Fast:
			return GamePropertiesScript.fastEnemySpeed;
			break;
		case EnemyType.Brute: 
			return GamePropertiesScript.bruteEnemySpeed;
			break;
		case EnemyType.FlyingNormal: 
			return GamePropertiesScript.flyingEnemySpeed;
			break;
		default:
			return GamePropertiesScript.normalEnemySpeed;
			break;
		}
	}
}
