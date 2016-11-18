using UnityEngine;
using System.Collections;

public class DumbEnemyScript : MonoBehaviour {

	public float speed = GamePropertiesScript.normalEnemySpeed;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3 (transform.position.x - speed * Time.deltaTime, transform.position.y, transform.position.z);
	
	}
}
