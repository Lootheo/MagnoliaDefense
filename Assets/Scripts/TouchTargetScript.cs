using UnityEngine;
using System.Collections;

public class TouchTargetScript : MonoBehaviour {

	public GameObject target;
	public GameObject tapShoot;
	public InstantiatorSphereScript isc;

	float x1,x2,y1,y2;
	public float MaxCooldown = 1.0f;
	float CurrentCooldown = 0.0f;
	void Start(){
		isc = GameObject.FindObjectOfType<InstantiatorSphereScript> ();
		x1 = -3.0f;
	}
	void Update() {
		
		if (CurrentCooldown > 0) {
			CurrentCooldown -= Time.deltaTime;
			tapShoot.GetComponent<Renderer> ().material.color = new Color (0.0f, 0.0f, 1.0f, 1.0f);
		} else {
			tapShoot.GetComponent<Renderer> ().material.color = new Color (1.0f, 0.0f, 0.0f, 1.0f);
			
		}

		#if UNITY_ANDROID
		if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved) {
			// Get movement of the finger since last frame
			Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;

			// Move object across XY plane
			target.transform.Translate(-touchDeltaPosition.x * speed, -touchDeltaPosition.y * speed, 0);
		}
		#endif
		#if UNITY_EDITOR

		//Si la posición del mouse está dentro de los boundaries, mueve el target.
		Vector3 temp = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,Input.mousePosition.y,10.0f));
		if(temp.x>x1){
			target.transform.position = new Vector3 (temp.x,target.transform.position.y, temp.z);
		}
		//Si aprietas el click, creas una bala con la dirección.
		if (Input.GetMouseButtonDown(0)) {
			if(CurrentCooldown <=0 ){
					isc.CallBullet();
					CurrentCooldown = MaxCooldown;

			}

		}

			
		#endif
	}
}
