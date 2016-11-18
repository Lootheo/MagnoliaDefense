using UnityEngine;
using System.Collections;

//Types of enemies
public enum EnemyType{Normal, Fast, Brute, FlyingNormal}

//Types of bullets
enum BulletType {Basic, Flame, Poison, Ice, Sticky, Bomb, Ghostly}

public class GamePropertiesScript
{
	//This Script handles the gameplay properties
	//Bullet Properties (Start or Lvl1)
	float startingBulletCooldown;
	float startingBulletSpeed;

	//Bullet Current Properties (Current)
	public float currentBulletCooldown = .8f;
	public float currentBulletSpeed;

	//Bullet Properties (Limits)
	float maxBulletCooldown;
	float minBulletCooldown;
	float maxBulletDistance;
	float maxBulletHeight;

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
	public float gravity = 120.0f;
	public float bulletMinTime = .5f;
	public float bulletMaxTime = 1.0f;
	public float bulletMaxDistance = 85;
	public float bulletMinDistance = 23;

	//Enemies moving Speed
	public static float normalEnemySpeed = 8.0f;
	public static float fastEnemySpeed = 15.0f;
	public static float bruteEnemySpeed = 5.0f;
	public static float flyingEnemySpeed = 5.0f;

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
