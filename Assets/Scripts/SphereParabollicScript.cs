using UnityEngine;
using System.Collections;

public class SphereParabollicScript : MonoBehaviour {
	public float desiredX =30;
	float x0;
	float y0;
	float vx0 = 3.0f;
	float altura = 0.0f;
	public Transform targetPoint;
	public float Speed;
	// Use this for initialization
	float v;
	float vy0;
	float velocityY;
	float g;
	float x,y;
	TowerManager tm;
	public Transform myTrans;

	public void SetData(TowerManager _tm, Transform _point)
	{
		tm = _tm;
		targetPoint = _point;
	}

	void Start () {
		g = tm.g;
		vx0 = tm.vx0;
		vy0 = tm.vy0;
		velocityY = vy0;
		myTrans = this.transform;
	}

	// Update is called once per frame
	void Update () {
		myTrans.position = new Vector3 (myTrans.position.x + Time.deltaTime*vx0, myTrans.position.y + velocityY*Time.deltaTime, 0);
		velocityY -= g*Time.deltaTime;
	}

	void OnTriggerEnter(Collider hit) {
		if (hit.gameObject.tag == "Enemy") {
			Destroy (hit.gameObject);
			Destroy (this.gameObject);
		}
	}
}
