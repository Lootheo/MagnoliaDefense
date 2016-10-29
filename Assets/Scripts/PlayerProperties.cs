using UnityEngine;
using System.Collections;

public class PlayerProperties : MonoBehaviour {

	//The Properties of the player (This is the one saved in the user phone to check progress)
	class Player {
		//Player Stats
		string playerName;
		int playerLevel;
		float playerExperience;
		int playerCoins;

		//Levels Stats
		int playerLevelsPassed;

	}
	//UpgradeClass with enum
	enum TypeUpgrade{Bullet, BulletCooldown,CauldronDamage,CauldronCooldown, AllyCooldown }
	class Upgrade{
		TypeUpgrade type;
		int level;
		int requiredLevel;
		int requiredCoins;

	
	}




	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
