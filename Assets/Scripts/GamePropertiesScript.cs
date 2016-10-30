using UnityEngine;
using System.Collections;

public class GamePropertiesScript
{
	//This Script handles the gameplay properties

	//Bullet Properties (Start or Lvl1)
	float startingBulletCooldown;
	float startingBulletSpeed;

	//Bullet Current Properties (Current)
	public float currentBulletCooldown = 1.0f;
	public float currentBulletSpeed;

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
	public float currentPlayerMaxHP = 100.0f;
	float currentPlayerExperience;
	float currentPlayerHP;
	int currentPlayerLevel;

	//Added for bullet countdown
	public float gravity = 9.81f;
	public float bulletMinTime = 1.0f;
	public float bulletMaxTime = 1.5f;
	public float bulletMaxDistance = 12;
	public float bulletMinDistance = 3;
}
