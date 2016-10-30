using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class TowerManager : MonoBehaviour {
	public Image healthBar;
	public float _health, maxHealth;
	public Transform ShootPoint, AllySpawn;
	public GameObject bullet;
	public GameObject[] allies;
	public Transform bulletParent;
	public List<GameObject> availableBullets = new List<GameObject> ();
	public GameObject marker;
	public Transform Canvas;
	public float vx0;
	public float vy0;
	public float x;
	public float y;
	public float g;
	public float time;
	public float minTime;
	public float maxTime;
	public float minDistance;
	public float maxDistance;
	public bool isPressing, canShot;
	float x1,x2,y1,y2;
	public float MaxCooldown = 1.0f;
	float CurrentCooldown = 0.0f;
	// Use this for initialization
	public GameObject[] guides;
	public Transform target;
	// Use this for initialization
	void Start () 
	{
		isPressing = false;
		guides = new GameObject[10];
		for (int i = 0; i < 10; i++) 
		{
			guides [i] = Instantiate (marker, ShootPoint.position, Quaternion.identity) as GameObject;
			guides [i].transform.SetParent (ShootPoint);
		}

		//Assigning properties based on GameProperties script
		GamePropertiesScript gps = new GamePropertiesScript ();
		g = gps.gravity;
		minTime = gps.bulletMinTime;
		maxTime = gps.bulletMaxTime;
		minDistance = gps.bulletMinDistance;
		maxDistance = gps.bulletMaxDistance;
		MaxCooldown = gps.currentBulletCooldown;
		maxHealth = gps.currentPlayerMaxHP;
		_health = maxHealth;
		x1 = -gps.bulletMinDistance;
	}

	public void SpawnAlly(int _type)
	{
		GameObject ally = Instantiate (allies [_type], AllySpawn.position, Quaternion.identity) as GameObject;
		ally.transform.localScale = new Vector3 (1, 1, 1);
		ally.transform.SetParent (Canvas);
		AllyScript AS = ally.GetComponent<AllyScript> ();
		AS.TM = this;
	}

	public void TakeDamage(float _dmg)
	{
		_health -= _dmg;
		Debug.Log (_health + " " + maxHealth);
		healthBar.fillAmount = _health / maxHealth;
	}

	public void CallBullet()
	{
		GameObject _bullet;
		if (availableBullets.Count > 0) 
		{
			_bullet = availableBullets[0];
			RemoveBullet (_bullet);
		} 
		else 
		{
			_bullet = Instantiate (bullet,ShootPoint.position,Quaternion.identity) as GameObject;
			_bullet.transform.SetParent (bulletParent);
		}
		BulletScript BS = _bullet.GetComponent<BulletScript> ();
		BS.SetData (this, target);
		canShot = false;
	}

	// Update is called once per frame
	void Update () {
		if (canShot)
		{
			if (Input.GetMouseButtonDown (0)) 
			{
//				for (int i = 0; i < guides.Length; i++) 
//				{
//					guides [i].SetActive (true);
//				}
				Vector3 pressPoint = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,Input.mousePosition.y, 10.0f));
				if(pressPoint.x > -3.0f)
				{
					target.position = new Vector3 (pressPoint.x,target.position.y, pressPoint.z);
				}
				x =  target.position.x- ShootPoint.position.x;
				y =  target.position.y- ShootPoint.position.y;
				//Esto establece que si estás más lejos el tiempo de la bala es mayor.
				time = minTime + ((maxTime - minTime) * (maxDistance/100.0f*x));


				vx0 = x/time;
				vy0 = (y/time)+(0.5f*g*(time));
				float guideTime = time / guides.Length;
				for (int i = 0; i < guides.Length; i++) 
				{
					float x1 =  ShootPoint.position.x + vx0 * guideTime*i ;
					float y1 = ShootPoint.position.y + vy0 * guideTime*i - 0.5f * g * Mathf.Pow((guideTime*i),2);
					guides [i].transform.position = new Vector3 (x1, y1, 0);
				}
				if (Time.time > CurrentCooldown) 
				{
					CallBullet ();
					CurrentCooldown = Time.time + MaxCooldown;
				}
			}
		}
//		if (canShot)
//		{
//			if (Input.GetMouseButtonDown (0)) 
//			{
//				isPressing = true;
//				for (int i = 0; i < guides.Length; i++) 
//				{
//					guides [i].SetActive (true);
//				}
//			}
//			if (Input.GetMouseButtonUp (0)) 
//			{
//				isPressing = false;
//				for (int i = 0; i < guides.Length; i++) 
//				{
//					guides [i].SetActive (false);
//				}
//				if (Time.time > CurrentCooldown) 
//				{
//					CallBullet ();
//					CurrentCooldown = Time.time + MaxCooldown;
//				}
//			}
//			if (isPressing) 
//			{
//				Vector3 pressPoint = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,Input.mousePosition.y, 10.0f));
//				if(pressPoint.x > -3.0f)
//				{
//					target.position = new Vector3 (pressPoint.x,target.position.y, pressPoint.z);
//				}
//				x =  target.position.x- ShootPoint.position.x;
//				y =  target.position.y- ShootPoint.position.y;
//				//Esto establece que si estás más lejos el tiempo de la bala es mayor.
//				time = minTime + ((maxTime - minTime) * (maxDistance/100.0f*x));
//
//
//				vx0 = x/time;
//				vy0 = (y/time)+(0.5f*g*(time));
//				float guideTime = time / guides.Length;
//				for (int i = 0; i < guides.Length; i++) 
//				{
//					float x1 =  ShootPoint.position.x + vx0 * guideTime*i ;
//					float y1 = ShootPoint.position.y + vy0 * guideTime*i - 0.5f * g * Mathf.Pow((guideTime*i),2);
//					guides [i].transform.position = new Vector3 (x1, y1, 0);
//				}
//			}
//		}
	}

	public void RestoreBullet(GameObject _bullet)
	{
		availableBullets.Add (_bullet);
		_bullet.transform.position = ShootPoint.position;
		_bullet.SetActive (false);
	}

	public void RemoveBullet(GameObject _bullet)
	{
		_bullet.SetActive (true);
		availableBullets.Remove (_bullet);
	}
}
