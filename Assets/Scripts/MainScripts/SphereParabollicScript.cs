using UnityEngine;
using System.Collections;

public class SphereParabollicScript : MonoBehaviour {
	public Transform targetPoint;
	// Use this for initialization
	float velocityY;

	public float g;
	float vx0;
	float vy0;
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
