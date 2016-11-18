using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EnemyScript : MonoBehaviour {

	public Image lifeBar;
	public float Health = 100.0f;
	float maxHealth;
	public float speed = 1.0f;
	public EnemySpawner ES;
	public bool _isAttacking;
	public bool _isAttackingTower;
	public bool _isAttackingAlly;
	public bool _canMove =true;
	public GameObject _target;
	public float _attackTime;
	public float _nextAttack;
	public float _attackDmg;
	AllyScript _ally;
	TowerManager _tower;
	public Renderer _rend;
	Material originalMaterial;
	public Color32 originalColor;
	public Material flashMaterial;


	// Use this for initialization
	void Start () {
		maxHealth = Health;
		originalMaterial = _rend.material;
		originalColor = _rend.material.color;
		_tower = FindObjectOfType<TowerManager> ();
		_isAttacking = false;
	}

	// Update is called once per frame
	void Update () {
		if (!_isAttacking && _canMove)
			transform.position = new Vector3 (transform.position.x - speed * Time.deltaTime, transform.position.y, transform.position.z);
		else 
		{
			if (Time.time > _nextAttack) 
			{
				if (_isAttackingAlly) 
				{
					if (_ally != null) {
						_ally.TakeDamage (_attackDmg);
						if (_ally == null || _ally.Health <=0) {
							_isAttacking = false;
							_canMove = true;
						}
					}
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
	new WaitForSeconds damageTickWaitTime = new WaitForSeconds(0.1f);
	public void TakeDamage(float _damage)
	{
		Health -= _damage;
		lifeBar.fillAmount = Health / maxHealth;
		if (Health <= 0) {
			ES.DestroyEnemy ();
			Destroy (gameObject);					///This needs to be switched to pooling
		} else {
			_rend.material = flashMaterial;
			StartCoroutine (damageTick ());
		}
	}

	IEnumerator damageTick(){
		yield return damageTickWaitTime;
		_rend.material = originalMaterial;
	}

	public void Freeze(float _duration)
	{
		StartCoroutine (Frozen (_duration));
	}

	IEnumerator Frozen(float duration)
	{
		_canMove = false;
		_rend.material.color = Color.blue;
		yield return new WaitForSeconds (duration);
		_rend.material.color = originalColor;
		_canMove = true;
	}

	public void Burn(float _duration)
	{
		StartCoroutine (Burned (_duration));
	}

	IEnumerator Burned(float duration)
	{
		_rend.material.color = Color.red;
		for (int i = 0; i < duration+2; i++) 
		{
			yield return new WaitForSeconds (2);
			TakeDamage (duration * 5);
		}
		_rend.material.color = originalColor;
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
//		if (hit.tag == "Enemy") {
//			_canMove = false;
//		}
	}
//	void OnTriggerExit(Collider other){
//		if (other.tag == "Enemy") {
//			_canMove = true;
//		}
//	}
}
