using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EnemyScript : MonoBehaviour {
	public float Speed, Health;
	public Image _health;
	// Use this for initialization
	void Start () {
		Health = 100;
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (-Speed * Time.deltaTime, 0, 0);
	}

	public void TakeDamage(float Dmg)
	{
		Health -= Dmg;
		_health.fillAmount -= (float)(Dmg/100);
		if (Health <= 0) 
		{
			Destroy (this.gameObject);
		}
	}
}
