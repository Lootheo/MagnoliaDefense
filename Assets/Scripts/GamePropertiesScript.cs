using UnityEngine;
using System.Collections;

public class GamePropertiesScript : MonoBehaviour {

	//This Script handles the gameplay properties

	//Bullet Properties (Start or Lvl1)
	float startingBulletCooldown;
	float startingBulletSpeed;

	//Bullet Current Properties (Current)
	float currentBulletCooldown;
	float currentBulletSpeed;

	//Bullet Properties (Limits)
	float maxBulletCooldown;
	float minBulletCooldown;
	float maxBulletDistance;
	float maxBulletHeight;

	//Types of bullets
	enum BulletType {Basic, Flame, Poison, Ice, Sticky, Bomb, Ghostly}

	//Cauldron Properties
	float startingCauldronDamage;
	float startingCauldronCooldown;

	//Gameplay Properties (Start or lvl 1)
	float startingPlayerMaxHP;
	float startingPlayerHP;
	float startingPlayerExperience;
	int startingPlayerLevel = 1;

	//Gameplay Properties (Current)
	float currentPlayerMaxHP;
	float currentPlayerExperience;
	float currentPlayerHP;
	int currentPlayerLevel;








	// Use this for initialization
	void Start () {
	


	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
