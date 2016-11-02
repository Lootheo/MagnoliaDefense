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
	public GameObject Explotion;

	public void SetData(TowerManager _tm, Transform _point, int _sel, int _dmg)
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
			myTrans.position = new Vector3 (myTrans.position.x + Time.deltaTime*vx0, myTrans.position.y + velocityY*Time.deltaTime, myTrans.position.z);
			velocityY -= g * Time.deltaTime;
		}
	}

	public int _damage;
	void OnTriggerEnter(Collider hit)
	{
		switch (_selectedType) 
		{
			case BulletType.Basic:
				if (hit.transform.tag == "Enemy") 
				{
					hit.SendMessage ("TakeDamage", _damage * 10);
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
					hit.SendMessage ("TakeDamage", _damage * 8);
					hit.SendMessage ("Burn", _damage);
				} 
				else if (hit.transform.tag == "Floor") 
				{
					tm.RestoreBullet (this.gameObject);
				}
				break;
			case BulletType.Ice:
				if (hit.transform.tag == "Enemy") 
				{
					hit.SendMessage ("TakeDamage", _damage * 12);
					hit.SendMessage ("Freeze", 0.5f);
					tm.RestoreBullet (this.gameObject);
				} 
				else if (hit.transform.tag == "Floor") 
				{
					tm.RestoreBullet (this.gameObject);
				}
				break;
			case BulletType.Bomb:
				if (hit.transform.tag == "Enemy") 
				{
					hit.SendMessage ("TakeDamage", _damage * 10);
					Detonate ();
					tm.RestoreBullet (this.gameObject);
				} 
				else if (hit.transform.tag == "Floor") 
				{
					Detonate ();
					tm.RestoreBullet (this.gameObject);
				}
				break;
		}
	}

	void Detonate()
	{
		Collider[] hitColliders = Physics.OverlapSphere(this.transform.position, 10 * _damage);
		foreach (Collider col in hitColliders) 
		{
			if (col.tag == "Enemy") 
			{
				col.SendMessage ("TakeDamage", _damage * 5);
			}
		}
		GameObject _boom = Instantiate (Explotion, this.transform.position, Quaternion.identity) as GameObject;
		_boom.transform.localScale = new Vector3 (10 * _damage, 10 * _damage, 10 * _damage);
		Destroy (_boom, 3.0f);
	}
}
