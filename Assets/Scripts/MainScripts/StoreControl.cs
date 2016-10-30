using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StoreControl : MonoBehaviour {
	public PrincessInfo _info;
	// Use this for initialization
	void Start () {
		//DataPrincess.Delete ();
		_info = DataPrincess.Load ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
