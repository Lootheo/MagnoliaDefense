using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EnemyScript : MonoBehaviour {

	public Image lifeBar;
	public float Health = 100.0f;
	public float speed = 1.0f;
	public EnemySpawner ES;
	public bool _isAttacking;
	public bool _isAttackingTower;
	public bool _isAttackingAlly;
	public GameObject _target;
	public float _attackTime;
	public float _nextAttack;
	public float _attackDmg;
	AllyScript _ally;
	TowerManager _tower;
	// Use this for initialization
	void Start () {
		_tower = FindObjectOfType<TowerManager> ();
		_isAttacking = false;
		Health = 100.0f;
		speed = 1.0f;
	}
	
	// Update is called once per frame
	void Update () {
		if (!_isAttacking)
			transform.position = new Vector3 (transform.position.x - speed * Time.deltaTime, transform.position.y, 0.0f);
		else 
		{
			if (Time.time > _nextAttack) 
			{
				if (_isAttackingAlly) 
				{
					if (_ally != null)
						_ally.TakeDamage (_attackDmg);
					else 
					{
						_isAttacking = false;
						_isAttackingAlly = false;
					}
				}
				_nextAttack = Time.time + _attackTime;
			}
		}
	}

	public void TakeDamage(float _damage)
	{
		Health -= _damage;
		lifeBar.fillAmount = Health / 100.0f;
		if(Health <= 0)
		{
			ES.DestroyEnemy ();
			Destroy (gameObject);
		}
	}



	void OnTriggerEnter(Collider hit)
	{
		if (hit.tag == "Ally") 
		{
			_isAttacking = true;
			_isAttackingAlly = true;
			_ally = hit.GetComponent<AllyScript> ();
		}
		if (hit.tag == "Tower") 
		{
			_tower.TakeDamage (_attackDmg);
			ES.DestroyEnemy ();
			Destroy (this.gameObject);
		}
	}
}
