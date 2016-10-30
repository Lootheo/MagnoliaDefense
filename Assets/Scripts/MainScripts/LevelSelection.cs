using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelection : MonoBehaviour {

	public Button[] _btnLevels;
	public List<LevelData> levels = new List<LevelData> ();
	public DataSender DS;
	
	public void SendData(int id)
	{
		DS._waves = levels [id].Waves;
		DS._enemysWave = levels [id].EnemysPerWave;
		DS._enemyTime = levels [id].EnemyTime;
		DS._waveTime = levels [id].WaveTime;
		SceneManager.LoadScene ("FinalScene");
	}
}
