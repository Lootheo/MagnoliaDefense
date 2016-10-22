using UnityEngine;
using System.Collections;

public class BulletScript : MonoBehaviour {
	public int _damage;

	void OnTriggerEnter(Collider hit)
	{
		if (hit.transform.tag == "Enemy") 
		{
			hit.SendMessage ("TakeDamage", (float)_damage);
		}
	}
}
