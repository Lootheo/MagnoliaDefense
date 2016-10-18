using UnityEngine;
using System.Collections;

public class SphereParabollicScript : MonoBehaviour {

	public float desiredX =30;
	float x0;
	float y0;
	float vx0 = 3.0f;
	float altura = 0.0f;
	public GameObject targetPoint;
	public GameObject bullet;
	public float Speed;
	// Use this for initialization
	float v;
	float vy0;

	float velocityY;

	float g;
	float x,y;

	InstantiatorSphereScript gm;


	void Start () {
		gm = Camera.main.gameObject.GetComponent<InstantiatorSphereScript>();
		bullet = gameObject;
		targetPoint = GameObject.FindGameObjectWithTag ("Target");

		g = gm.g;
		vx0 = gm.vx0;
		vy0 = gm.vy0;
		velocityY = vy0;


	}

	// Update is called once per frame
	void Update () {
		Vector3 bulletPos = bullet.transform.position;
		bullet.transform.position = new Vector3 (bulletPos.x + Time.deltaTime*vx0, bulletPos.y + velocityY*Time.deltaTime, 0);
		velocityY -= g*Time.deltaTime;
	}
}
