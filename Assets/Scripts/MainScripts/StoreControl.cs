using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StoreControl : MonoBehaviour {
	[System.Serializable]
	public class StoreBomb
	{
		public Button unlockBtn;
		public Image bombBgd;
		public Text _unlockPrice;
		public Button DmgBtn;
		public Text dmgTxt;
		public Button CoolBtn;
		public Text coolTxt;
	}

	public Text GoldValue;
	public PrincessInfo _info;
	public StoreBomb[] _bombs;
	public int _fireUnlockPrice;
	public int _iceUnlockPrice;
	public int _bombUnlockPrice;
	public int _normalUpgradeDmgPrice;
	public int _fireUpgradeDmgPrice;
	public int _iceUpgradeDmgPrice;
	public int _bombUpgradeDmgPrice;
	public int _normalUpgradeCoolPrice;
	public int _fireUpgradeCoolPrice;
	public int _iceUpgradeCoolPrice;
	public int _bombUpgradeCoolPrice;
	// Use this for initialization
	void Start () {
		//DataPrincess.Delete ();
		_info = DataPrincess.Load ();
		GoldValue.text = _info.gold.ToString();
		Check ();
		SetNewPrice (0);
		SetNewPrice (1);
		SetNewPrice (2);
		SetNewPrice (3);
	}

	public void Check()
	{
		_bombs [0].CoolBtn.gameObject.SetActive (true);
		_bombs [0].DmgBtn.gameObject.SetActive (true);
		if(_info.gold<_normalUpgradeCoolPrice)
			_bombs [0].CoolBtn.interactable = false;
		else
			_bombs [0].CoolBtn.interactable = true;
		if(_info.gold<_normalUpgradeDmgPrice)
			_bombs [0].DmgBtn.interactable = false;
		else
			_bombs [0].DmgBtn.interactable = true;


		if (!_info.fireShot) 
		{
			_bombs [1].unlockBtn.gameObject.SetActive (true);
			if (_info.gold < _fireUnlockPrice) 
			{
				_bombs [1].unlockBtn.interactable = false;
				_bombs [1].CoolBtn.gameObject.SetActive (false);
				_bombs [1].DmgBtn.gameObject.SetActive (false);

			} 
		}
		else 
		{
			_bombs [1].unlockBtn.gameObject.SetActive (false);
			_bombs [1].CoolBtn.gameObject.SetActive (true);
			_bombs [1].DmgBtn.gameObject.SetActive (true);
			if(_info.gold<_fireUpgradeCoolPrice)
				_bombs [1].CoolBtn.interactable = false;
			else
				_bombs [1].CoolBtn.interactable = true;
			if(_info.gold<_fireUpgradeDmgPrice)
				_bombs [1].DmgBtn.interactable = false;
			else
				_bombs [1].DmgBtn.interactable = true;
		}


		if (!_info.iceShot) 
		{
			_bombs [2].unlockBtn.gameObject.SetActive (true);
			if (_info.gold < _iceUnlockPrice) 
			{
				_bombs [2].unlockBtn.interactable = false;
				_bombs [2].CoolBtn.gameObject.SetActive (false);
				_bombs [2].DmgBtn.gameObject.SetActive (false);
			} 
		}
		else 
		{
			_bombs [2].unlockBtn.gameObject.SetActive (false);
			_bombs [2].CoolBtn.gameObject.SetActive (true);
			_bombs [2].DmgBtn.gameObject.SetActive (true);
			if(_info.gold<_iceUpgradeCoolPrice)
				_bombs [2].CoolBtn.interactable = false;
			else
				_bombs [2].CoolBtn.interactable = true;
			if(_info.gold<_iceUpgradeDmgPrice)
				_bombs [2].DmgBtn.interactable = false;
			else
				_bombs [2].DmgBtn.interactable = true;
		}


		if (!_info.bombShot) 
		{
			_bombs [3].unlockBtn.gameObject.SetActive (true);
			if (_info.gold < _bombUnlockPrice) 
			{
				_bombs [3].unlockBtn.interactable = false;
				_bombs [3].CoolBtn.gameObject.SetActive (false);
				_bombs [3].DmgBtn.gameObject.SetActive (false);

			} 
		}
		else 
		{
			_bombs [3].unlockBtn.gameObject.SetActive (false);
			_bombs [3].CoolBtn.gameObject.SetActive (true);
			_bombs [3].DmgBtn.gameObject.SetActive (true);
			if(_info.gold<_bombUpgradeCoolPrice)
				_bombs [3].CoolBtn.interactable = false;
			else
				_bombs [3].CoolBtn.interactable = true;
			if(_info.gold<_bombUpgradeDmgPrice)
				_bombs [3].DmgBtn.interactable = false;
			else
				_bombs [3].DmgBtn.interactable = true;
		}
	}

	public void SaveNewData()
	{
		DataPrincess.Save (_info);
		SceneManager.LoadScene ("LevelSelection");
	}

	public void SetNewPrice(int _index)
	{
		switch (_index) 
		{
			case 0:
				_normalUpgradeCoolPrice = _info.NormalBulletCooldown * 10;
				_bombs [0].coolTxt.text = "Cooldown Lvl " + (_info.NormalBulletCooldown+1) + " $" + _normalUpgradeCoolPrice;
				_normalUpgradeDmgPrice = _info.NormalBulletDamage * 10;
				_bombs [0].dmgTxt.text = "Dmg Lvl " + (_info.NormalBulletDamage+1) + " $" + _normalUpgradeDmgPrice;
				break;
			case 1:
				_fireUpgradeCoolPrice = _info.FireBulletCooldown * 10;
				_bombs [1].coolTxt.text = "Cooldown Lvl " + (_info.FireBulletCooldown+1) + " $" + _fireUpgradeCoolPrice;
				_fireUpgradeDmgPrice = _info.FireBulletDamage * 10;
				_bombs [1].dmgTxt.text = "Dmg Lvl " + (_info.FireBulletDamage+1) + " $" + _fireUpgradeDmgPrice;
				break;
			case 2:
				_iceUpgradeCoolPrice = _info.IceBulletCooldown * 10;
				_bombs [2].coolTxt.text = "Cooldown Lvl " + (_info.IceBulletCooldown+1) + " $" + _iceUpgradeCoolPrice;
				_iceUpgradeDmgPrice = _info.IceBulletDamage * 10;
				_bombs [2].dmgTxt.text = "Dmg Lvl " + (_info.IceBulletDamage+1) + " $" + _iceUpgradeDmgPrice;
				break;
			case 3:
				_bombUpgradeCoolPrice = _info.BombBulletCooldown * 10;
				_bombs [3].coolTxt.text = "Cooldown Lvl " + (_info.BombBulletCooldown+1) + " $" + _bombUpgradeCoolPrice;
				_bombUpgradeDmgPrice = _info.BombBulletDamage * 10;
				_bombs [3].dmgTxt.text = "Dmg Lvl " + (_info.BombBulletDamage+1) + " $" + _bombUpgradeDmgPrice;
				break;
		}
	}
	
	public void UnlockShot(int _type)
	{
		switch (_type) 
		{
			case 1:
				_info.fireShot = true;
				_info.gold -= _fireUnlockPrice;
				break;
			case 2:
				_info.iceShot = true;
				_info.gold -= _iceUnlockPrice;
				break;
			case 3:
				_info.bombShot = true;
				_info.gold -= _bombUnlockPrice;
				break;
		}
		GoldValue.text = _info.gold.ToString();
		Check ();
	}

	public void UpgradeDamage(int _type)
	{
		switch (_type) 
		{
			case 0:
				_info.NormalBulletDamage++;
				_info.gold -= _normalUpgradeDmgPrice;
				break;
			case 1:
				_info.FireBulletDamage++;
				_info.gold -= _fireUpgradeDmgPrice;
				break;
			case 2:
				_info.IceBulletDamage++;
				_info.gold -= _iceUpgradeDmgPrice;
				break;
			case 3:
				_info.BombBulletDamage++;
				_info.gold -= _bombUpgradeDmgPrice;
				break;
		}
		GoldValue.text = _info.gold.ToString();
		SetNewPrice (_type);
		Check ();
	}

	public void UpgradeCooldown(int _type)
	{
		switch (_type) 
		{
			case 0:
				_info.NormalBulletCooldown++;
				_info.gold -= _normalUpgradeCoolPrice;
				break;
			case 1:
				_info.FireBulletCooldown++;
				_info.gold -= _fireUpgradeCoolPrice;
				break;
			case 2:
				_info.IceBulletCooldown++;
				_info.gold -= _iceUpgradeCoolPrice;
				break;
			case 3:
				_info.BombBulletCooldown++;
				_info.gold -= _bombUpgradeCoolPrice;
				break;
		}
		GoldValue.text = _info.gold.ToString();
		SetNewPrice (_type);
		Check ();
	}
}
