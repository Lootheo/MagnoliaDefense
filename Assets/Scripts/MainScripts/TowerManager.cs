using UnityEngine;
using System.Collections;

public class TowerManager : MonoBehaviour {
	public Transform ShootPoint;
	public GameObject bullet;
	public GameObject marker;
	public float vx0;
	public float vy0;
	public float x;
	public float y;
	public float g=9.81f;
	public float time=1.2f;
	public float minTime = 1.0f;
	public float maxTime = 1.5f;
	public float maxDistance = 12.0f;
	public bool isPressing;
	float x1,x2,y1,y2;
	public float MaxCooldown = 1.0f;
	float CurrentCooldown = 0.0f;
	// Use this for initialization
	public GameObject[] guides;

	public Transform target;
	// Use this for initialization
	void Start () {
		x1 = -3.0f;
		isPressing = false;
		guides = new GameObject[10];
		for (int i = 0; i < 10; i++) 
		{
			guides [i] = Instantiate (marker, ShootPoint.position, Quaternion.identity) as GameObject;
			guides [i].transform.SetParent (ShootPoint);
		}
		
	}


	IEnumerator InstantiateSphere(){
		while(true)
		{
			yield return new WaitForSeconds (2.0f);
			Instantiate (bullet,ShootPoint.position,Quaternion.identity);
		}
	}
	public void CallBullet()
	{
		GameObject _bullet = Instantiate (bullet,ShootPoint.position,Quaternion.identity) as GameObject;
		SphereParabollicScript SPS = _bullet.GetComponent<SphereParabollicScript> ();
		SPS.SetData (this, target);
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) 
		{
			isPressing = true;
			for (int i = 0; i < guides.Length; i++) 
			{
				guides [i].SetActive (true);
			}
		}
		if (Input.GetMouseButtonUp (0)) 
		{
			isPressing = false;
			for (int i = 0; i < guides.Length; i++) 
			{
				guides [i].SetActive (false);
			}
			if (Time.time > CurrentCooldown) 
			{
				CallBullet ();
				CurrentCooldown = Time.time + MaxCooldown;
			}
		}
		if (isPressing) 
		{
			Vector3 pressPoint = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,Input.mousePosition.y, 10.0f));
			if(pressPoint.x > -3.0f)
			{
				target.position = new Vector3 (pressPoint.x,target.position.y, pressPoint.z);
			}
			x =  target.position.x- ShootPoint.position.x;
			y =  target.position.y- ShootPoint.position.y;
			//Esto establece que si estás más lejos el tiempo de la bala es mayor.
			time = minTime + ((maxTime - minTime) * (maxDistance/100.0f*x));


			vx0 = x/time;
			vy0 = (y/time)+(0.5f*g*(time));
			float guideTime = time / guides.Length;
			for (int i = 0; i < guides.Length; i++) 
			{
				float x1 =  ShootPoint.position.x + vx0 * guideTime*i ;
				float y1 = ShootPoint.position.y + vy0 * guideTime*i - 0.5f * g * Mathf.Pow((guideTime*i),2);
				guides [i].transform.position = new Vector3 (x1, y1, 0);
			}
		}
		//Obtener la distancia de la torre a la bala
	}
}
