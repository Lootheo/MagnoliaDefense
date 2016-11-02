using UnityEngine;
using System.Collections;

public class UIControl : MonoBehaviour {
	public GameObject[] screens;
	public int current;
	// Use this for initialization
	void Start () {
		current = 0;
		screens [1].SetActive (false);
		screens [2].SetActive (false);
	}

	public void Next()
	{
		screens [current].SetActive (false);
		if (current < screens.Length - 1) {
			current++;
		} else 
		{
			current = 0;
		}
		screens [current].SetActive (true);
	}

	public void Prev()
	{
		screens [current].SetActive (false);
		if (current > 0) {
			current--;
		} else 
		{
			current = screens.Length-1;
		}
		screens [current].SetActive (true);
	}
}
