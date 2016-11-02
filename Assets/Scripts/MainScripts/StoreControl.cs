using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StoreControl : MonoBehaviour {
	[System.Serializable]
	public class StoreBomb
	{
		public Button unlockBtn;
		public Button DmgBtn;
		public Text dmgTxt;
		public Button CoolBtn;
		public Text coolTxt;
	}

	[System.Serializable]
	public class StoreAlly
	{
		public Button UnlockBtn;
		public Text UnlockTxt;
	}

	public Text GoldValue;
	public PrincessInfo _info;
	public StoreBomb[] _bombs;
	public StoreAlly[] _allies;
	public StoreBomb _caldero;
	public Button HealthBtn;
	public Text HealthTxt;
	public int _fireUnlockPrice;
	public int _iceUnlockPrice;
	public int _bombUnlockPrice;
	public int _normalUpgradeDmgPrice;
	public int _fireUpgradeDmgPrice;
	public int _iceUpgradeDmgPrice;
	public int _bombUpgradeDmgPrice;
	public int _CauldronUpgradeDmgPrice;
	public int _normalUpgradeCoolPrice;
	public int _fireUpgradeCoolPrice;
	public int _iceUpgradeCoolPrice;
	public int _bombUpgradeCoolPrice;
	public int _CauldronUpgradeCoolPrice;
	public int _HealthUpgradePrice;
	public int _Ally1UnlockPrice;
	public int _Ally2UnlockPrice;
	public int _Ally3UnlockPrice;
	// Use this for initialization
	void Start () {
		DataPrincess.Delete ();
		_info = DataPrincess.Load ();
		GoldValue.text = _info.gold.ToString();
		_bombs [0].CoolBtn.gameObject.SetActive (true);
		_bombs [0].DmgBtn.gameObject.SetActive (true);
		_caldero.DmgBtn.gameObject.SetActive (true);
		_caldero.CoolBtn.gameObject.SetActive (true);
		HealthBtn.gameObject.SetActive (true);
		Check ();
		SetNewPrice (0);
		SetNewPrice (1);
		SetNewPrice (2);
		SetNewPrice (3);
		SetNewPrice (4);
		SetNewPrice (5);
	}

	public void Check()
	{
		if(_info.gold<_normalUpgradeCoolPrice)
			_bombs [0].CoolBtn.interactable = false;
		else
			_bombs [0].CoolBtn.interactable = true;
		if(_info.gold<_normalUpgradeDmgPrice)
			_bombs [0].DmgBtn.interactable = false;
		else
			_bombs [0].DmgBtn.interactable = true;


		if(_info.gold<_HealthUpgradePrice)
			HealthBtn.interactable = false;
		else
			HealthBtn.interactable = true;


		if(_info.gold<_CauldronUpgradeCoolPrice)
			_caldero.CoolBtn.interactable = false;
		else
			_caldero.CoolBtn.interactable = true;

		if(_info.gold<_CauldronUpgradeCoolPrice)
			_caldero.CoolBtn.interactable = false;
		else
			_caldero.CoolBtn.interactable = true;
		if(_info.gold<_CauldronUpgradeDmgPrice)
			_caldero.DmgBtn.interactable = false;
		else
			_caldero.DmgBtn.interactable = true;


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

		if (!_info.ally1) 
		{
			if (_info.gold >= _Ally1UnlockPrice) {
				_allies [0].UnlockBtn.interactable = true;
			} else {
				_allies [0].UnlockBtn.interactable = false;
			}
			_allies [0].UnlockTxt.text = "Desbloquear Aliado $" + _Ally1UnlockPrice;
		} 
		else 
		{
			_allies [0].UnlockBtn.interactable = false;
			_allies [0].UnlockTxt.text = "Aliado Desbloqueado";
		}
		if (!_info.ally2) 
		{
			if (_info.gold >= _Ally2UnlockPrice) {
				_allies [1].UnlockBtn.interactable = true;
			} else {
				_allies [1].UnlockBtn.interactable = false;
			}
			_allies [1].UnlockTxt.text = "Desbloquear Aliado $" + _Ally2UnlockPrice;
		} 
		else 
		{
			_allies [1].UnlockBtn.interactable = false;
			_allies [1].UnlockTxt.text = "Aliado Desbloqueado";
		}

		if (!_info.ally3) 
		{
			if (_info.gold >= _Ally3UnlockPrice) 
			{
				_allies [2].UnlockBtn.interactable = true;
			} else 
			{
				_allies [2].UnlockBtn.interactable = false;
			}
			_allies [2].UnlockTxt.text = "Desbloquear Aliado $" + _Ally3UnlockPrice;
		} 
		else 
		{
			_allies [2].UnlockBtn.interactable = false;
			_allies [2].UnlockTxt.text = "Aliado Desbloqueado";
		}
	}

	public void UnlockAlly(int _dex)
	{
		switch (_dex) 
		{
			case 0:
				_info.ally1 = true;
				_info.gold -= _Ally1UnlockPrice;
				break;
			case 1:
				_info.ally2 = true;
				_info.gold -= _Ally2UnlockPrice;
				break;
			case 2:
				_info.ally3 = true;
				_info.gold -= _Ally3UnlockPrice;
				break;
		}
		GoldValue.text = _info.gold.ToString();
		Check ();
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
			case 4:
				_CauldronUpgradeCoolPrice = _info.CauldronCooldown * 10;
				_caldero.coolTxt.text = "Cooldown Lvl " + (_info.CauldronCooldown+1) + " $" + _CauldronUpgradeCoolPrice;
				_CauldronUpgradeDmgPrice = _info.CauldronDamage * 10;
				_caldero.dmgTxt.text = "Dmg Lvl " + (_info.CauldronDamage+1) + " $" + _CauldronUpgradeDmgPrice;
				break;
			case 5:
				_HealthUpgradePrice = _info.PlayerHP * 20;
				HealthTxt.text = "Health Lvl " + (_info.PlayerHP + 1) + " $" + _HealthUpgradePrice;
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

	public void UpgradeHealth()
	{
		_info.PlayerHP++;
		_info.gold -= _HealthUpgradePrice;
		GoldValue.text = _info.gold.ToString();
		SetNewPrice (5);
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
			case 4:
				_info.CauldronDamage++;
				_info.gold -= _CauldronUpgradeDmgPrice;
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
			case 4:
				_info.CauldronCooldown++;
				_info.gold -= _CauldronUpgradeCoolPrice;
				break;
		}
		GoldValue.text = _info.gold.ToString();
		SetNewPrice (_type);
		Check ();
	}
}
