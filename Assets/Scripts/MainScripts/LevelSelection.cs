using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class LevelSelection : MonoBehaviour {

	public GameObject _levelSelect, _ammoSelect;
	public Button[] _btnLevels;
	public List<LevelData> levels = new List<LevelData> ();
	public DataSender DS;
	public Image[] _ammoImages;
	public int AmmoOption = 0;
	public int LevelOption = 0;

	void Start()
	{
		_ammoImages [0].color = Color.yellow;
		_ammoSelect.SetActive (false);
	}

	public void SetSelected(int _sel)
	{
		AmmoOption = _sel;
		for (int i = 0; i < _ammoImages.Length; i++) 
		{
			_ammoImages [i].color = Color.white;
		}
		_ammoImages [_sel].color = Color.yellow;
	}

	public void SelectAmmo(int id)
	{
		LevelOption = id;
		_levelSelect.SetActive (false);
		_ammoSelect.SetActive (true);
	}
	
	public void SendData()
	{
		DS._waves = levels [LevelOption].Waves;
		DS._enemysWave = levels [LevelOption].EnemysPerWave;
		DS._enemyTime = levels [LevelOption].EnemyTime;
		DS._waveTime = levels [LevelOption].WaveTime;
		DS._bulletType = AmmoOption;
		SceneManager.LoadScene ("FinalScene");
	}
}
