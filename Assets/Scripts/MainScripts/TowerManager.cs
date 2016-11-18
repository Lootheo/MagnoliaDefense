using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class TowerManager : MonoBehaviour {
	public GameObject[] _bullets;
	public Transform CannonBody;
	public Image healthBar;
	public Button[] _allies;
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
	float minTime;
	float maxTime;
	public float minDistance;
	public float maxDistance;
	public bool isPressing, canShot;
	float x1,x2,y1,y2;
	public float MaxCooldown = 1.0f;
	float CurrentCooldown = 0.0f;
	int _selectedType;
	// Use this for initialization
	public GameObject[] guides;
	public Transform target;
	public PrincessInfo _info;

	// Use this for initialization
	void Start () 
	{
		_info = DataPrincess.Load ();
		isPressing = false;
		guides = new GameObject[20];
		for (int i = 0; i < 20; i++) 
		{
			guides [i] = Instantiate (marker, ShootPoint.position, Quaternion.identity) as GameObject;
			guides [i].transform.SetParent (ShootPoint);
		}
		DataSender _sender = GameObject.FindObjectOfType<DataSender>();
		if (_sender != null) {
			bullet = _bullets [_sender._bulletType];
			_selectedType = _sender._bulletType;
		} 
		else 
		{
			bullet = _bullets [0];
		}


		GamePropertiesScript gps = new GamePropertiesScript ();	//Assigning properties based on GameProperties script
		g = gps.gravity;
		minTime = gps.bulletMinTime;
		maxTime = gps.bulletMaxTime;
		minDistance = gps.bulletMinDistance;
		maxDistance = gps.bulletMaxDistance;
		MaxCooldown = gps.currentBulletCooldown;
		if (_info.ally1) {
			_allies [0].gameObject.SetActive (true);
		} else {
			_allies [0].gameObject.SetActive (false);
		}

		if (_info.ally2) {
			_allies [1].gameObject.SetActive (true);
		} else {
			_allies [1].gameObject.SetActive (false);
		}

		if (_info.ally3) {
			_allies [2].gameObject.SetActive (true);
		} else {
			_allies [2].gameObject.SetActive (false);
		}
		switch (_selectedType) 
		{
			case 0:
				MaxCooldown -= _info.NormalBulletCooldown * 0.1f;
				break;
			case 1:
				MaxCooldown -= _info.FireBulletCooldown * 0.1f;
				break;
			case 2:
				MaxCooldown -= _info.IceBulletCooldown * 0.1f;
				break;
			case 3:
				MaxCooldown -= _info.BombBulletCooldown * 0.1f;
				break;
			}
		maxHealth = gps.currentPlayerMaxHP + (_info.PlayerHP*10) -10;
		_health = maxHealth;
		x1 = -gps.bulletMinDistance;
		target.gameObject.SetActive (false);
	}


	/// <summary>
	/// Spawns the ally.
	/// </summary>
	/// <param name="_type">The type of ally to spawn.</param>
	public void SpawnAlly(int _type)
	{
		GameObject ally = Instantiate (allies [_type], AllySpawn.position, Quaternion.identity) as GameObject;
		ally.transform.localScale = new Vector3 (1, 1, 1);
		ally.transform.SetParent (Canvas);
		AllyScript AS = ally.GetComponent<AllyScript> ();
		AS.TM = this;
	}
	/// <summary>
	/// Manages the tower damage intake
	/// </summary>
	/// <param name="_dmg">Dmg.</param>
	public void TakeDamage(float _dmg)
	{
		_health -= _dmg;
		Debug.Log (_health + " " + maxHealth);
		if (_health <= 0) {
			Loose ();
		}
		healthBar.fillAmount = _health / maxHealth;
	}

	public void Loose(){
		Debug.Log ("Loose");
	}

	/// <summary>
	/// Calls the bullet.
	/// </summary>
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
		if (BS == null) 
		{
			BS = _bullet.AddComponent<BulletScript> ();
		}
		int damage = 0;
		switch (_selectedType) 
		{
			case 0:
				damage = _info.NormalBulletDamage;
				break;
			case 1:
				damage = _info.FireBulletDamage;
				break;
			case 2:
				damage = _info.IceBulletDamage;
				break;
			case 3:
				damage = _info.BombBulletDamage;
				break;
		}
		BS.SetData (this, target, _selectedType, damage);
		canShot = false;
	}

	// Update is called once per frame
	void Update () {

			if (Input.GetMouseButton (0)) {
				target.gameObject.SetActive (true);
				isPressing = true;
				target.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,Input.mousePosition.y, 10.0f+ShootPoint.position.z));
				x =  target.position.x- ShootPoint.position.x;
				y =  target.position.y- ShootPoint.position.y;
				//Esto establece que si estás más lejos el tiempo de la bala es mayor.
				time = minTime+((maxTime - minTime) * ((maxDistance/100.0f)*(x/100.0f)));
				vx0 = x/time;
				vy0 = (y/time)+(0.5f*g*(time));
				float guideTime = time / 5.0f;

				float x1 =  ShootPoint.position.x + vx0 * guideTime*5.0f ;
				float y1 = ShootPoint.position.y + vy0 * guideTime*5.0f - 0.5f * g * Mathf.Pow((guideTime*1.0f),2);
				CannonBody.LookAt (new Vector3(x1,y1,CannonBody.transform.position.z));
				if (Time.time > CurrentCooldown) {
					CallBullet ();
					CurrentCooldown = Time.time + MaxCooldown;
				}
//				
				
			} else {
				target.gameObject.SetActive (false);
			}

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
