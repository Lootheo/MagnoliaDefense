using UnityEngine;
using System.Collections;

public class InstantiatorSphereScript : MonoBehaviour {
	public Object sphere;
	public float vx0;
	public float vy0;
	public float x;
	public float y;
	public float g=9.81f;
	public float time=1.2f;
	public float minTime = 1.0f;
	public float maxTime = 1.5f;
	public float maxDistance = 12.0f;


	public GameObject[] guides;

	public GameObject target;

	public GameObject startPos;
	// Use this for initialization
	void Start () {
		target = GameObject.FindGameObjectWithTag ("Target");
		guides = GameObject.FindGameObjectsWithTag ("Guide");
		//StartCoroutine(InstantiateSphere());

	}
	IEnumerator InstantiateSphere(){
		while(true){
			yield return new WaitForSeconds (2.0f);
			Instantiate (sphere,new Vector3(startPos.transform.position.x,startPos.transform.position.y,0.0f),Quaternion.identity);
		}
	}
	public void CallBullet(){
		Instantiate (sphere,new Vector3(startPos.transform.position.x,startPos.transform.position.y,0.0f),Quaternion.identity);
	}
	
	// Update is called once per frame
	void Update () {
		
		//Obtener la distancia de la torre a la bala
		x =  target.transform.position.x- startPos.transform.position.x;
		y =  target.transform.position.y- startPos.transform.position.y ;
		//Esto establece que si estás más lejos el tiempo de la bala es mayor.
		time = minTime + ((maxTime - minTime) * (maxDistance/100.0f*x));


		vx0 = x/time;
		vy0 = (y/time)+(0.5f*g*(time));
		float guideTime = time / guides.Length;
		for (int i = 0; i < guides.Length; i++) {
			float x1 =  startPos.transform.position.x + vx0 * guideTime*i ;
			float y1 = startPos.transform.position.y + vy0 * guideTime*i - 0.5f * g * Mathf.Pow((guideTime*i),2);
			guides [i].transform.position = new Vector3 (x1, y1, 0);
		}
	}
}
