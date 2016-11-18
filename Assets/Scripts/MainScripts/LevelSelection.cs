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
	public Button[] _ammoImages;
	public int AmmoOption = 0;
	public int LevelOption = 0;
	public PrincessInfo pi;

	void Start()
	{
		pi = DataPrincess.Load();
		for (int i = 0; i < _btnLevels.Length; i++) 
		{
			if (i <= pi.unlockedLevels-1) 
			{
				_btnLevels [i].interactable = true;
			} 
			else 
			{
				_btnLevels [i].interactable = false;
			}
		}
		if (pi.fireShot) {
			_ammoImages [1].interactable = true;
		} else {
			_ammoImages [1].interactable = false;
		}
		if (pi.iceShot) {
			_ammoImages [2].interactable = true;
		} else {
			_ammoImages [2].interactable = false;
		}
		if (pi.bombShot) {
			_ammoImages [3].interactable = true;
		} else {
			_ammoImages [3].interactable = false;
		}
		_ammoImages[0].GetComponent<Image>().color = Color.yellow;
		_ammoSelect.SetActive (false);
	}


	public void SetSelected(int _sel)
	{
		AmmoOption = _sel;
		for (int i = 0; i < _ammoImages.Length; i++) 
		{
			_ammoImages [i].GetComponent<Image>().color = Color.white;
		}
		_ammoImages [_sel].GetComponent<Image>().color = Color.yellow;
	}

	public void SelectAmmo(int id)
	{
		LevelOption = id;
		_levelSelect.SetActive (false);
		_ammoSelect.SetActive (true);
	}
	
	public void SendData()
	{
		DS.level = LevelOption;
		Debug.Log (DS.level);
		SceneManager.LoadScene ("FinalScene");
	}
}
