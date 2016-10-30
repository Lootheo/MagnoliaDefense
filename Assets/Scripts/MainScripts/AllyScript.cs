using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AllyScript : MonoBehaviour {
	public Image lifeBar;
	public float Health = 100.0f;
	public float speed = 1.0f;
	public TowerManager TM;
	public bool _isAttacking;
	public bool _canMove=true;
	public float _attackTime;
	public float _nextAttack;
	public float _attackDmg;
	public GameObject _target;
	public EnemyScript enemy;
	// Use this for initialization
	void Start () {
		_isAttacking = false;
		Health = 100.0f;
		speed = 1.0f;
	}

	// Update is called once per frame
	void Update () {
		if (!_isAttacking && _canMove)
			transform.position = new Vector3 (transform.position.x + speed * Time.deltaTime, transform.position.y, 0.0f);
		else 
		{
			if (Time.time > _nextAttack) 
			{
				if (_target != null) {
					enemy.TakeDamage (_attackDmg);
					if (enemy.Health <= 0) {
						_isAttacking = false;
						_canMove = true;
					}
					if (_target == null) {
						_isAttacking = false;
						_canMove = false;
					}
				}
				else 
				{
					_isAttacking = false;
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
			Destroy (gameObject);
		}
	}

	void OnTriggerEnter(Collider hit)
	{
		if (hit.tag == "Enemy" && !_isAttacking) 
		{
			_isAttacking = true;
			enemy = hit.GetComponent<EnemyScript> ();
			_target= hit.gameObject;
		}
	}

	void OnTriggerExit(Collider other){
		if (other.tag == "Ally") {
			_canMove = true;
		}
	}
}
