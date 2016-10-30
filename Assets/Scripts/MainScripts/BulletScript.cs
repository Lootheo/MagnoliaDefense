using UnityEngine;
using System.Collections;

public class BulletScript : MonoBehaviour {
	public Transform targetPoint;
	// Use this for initialization
	float velocityY;

	public float g;
	float vx0;
	float vy0;
	TowerManager tm;
	public Transform myTrans;
	public bool _isActive;
	public enum BulletType {Basic, Flame, Ice, Bomb};
	public BulletType _selectedType;

	public void SetData(TowerManager _tm, Transform _point, int _sel, float _dmg)
	{
		_isActive = true;
		tm = _tm;
		targetPoint = _point;
		g = tm.g;
		vx0 = tm.vx0;
		vy0 = tm.vy0;
		velocityY = vy0;
		myTrans = this.transform;
		_selectedType = (BulletType)_sel;
		_damage = _dmg;
	}

	// Update is called once per frame
	void Update () 
	{
		if (_isActive) 
		{
			myTrans.position = new Vector3 (myTrans.position.x + Time.deltaTime*vx0, myTrans.position.y + velocityY*Time.deltaTime, 0);
			velocityY -= g * Time.deltaTime;
		}
	}

	public float _damage;
	void OnTriggerEnter(Collider hit)
	{
		switch (_selectedType) 
		{
			case BulletType.Basic:
				if (hit.transform.tag == "Enemy") 
				{
					hit.SendMessage ("TakeDamage", _damage);
					tm.RestoreBullet (this.gameObject);
				} 
				else if (hit.transform.tag == "Floor") 
				{
					tm.RestoreBullet (this.gameObject);
				}
				break;
			case BulletType.Flame:
				if (hit.transform.tag == "Enemy") 
				{
					hit.SendMessage ("TakeDamage", _damage);
				} 
				else if (hit.transform.tag == "Floor") 
				{
					tm.RestoreBullet (this.gameObject);
				}
				break;
			case BulletType.Ice:
				if (hit.transform.tag == "Enemy") 
				{
					hit.SendMessage ("TakeDamage", _damage);
				} 
				else if (hit.transform.tag == "Floor") 
				{
					tm.RestoreBullet (this.gameObject);
				}
				break;
			case BulletType.Bomb:
				if (hit.transform.tag == "Enemy") 
				{
					hit.SendMessage ("TakeDamage", _damage);
				} 
				else if (hit.transform.tag == "Floor") 
				{
					tm.RestoreBullet (this.gameObject);
				}
				break;
		}
	}

	void Blaze()
	{
		
	}

	void Freeze()
	{
		
	}

	void Detonate()
	{
		
	}
}
