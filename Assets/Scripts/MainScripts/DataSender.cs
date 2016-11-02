using UnityEngine;
using System.Collections;

public class DataSender : MonoBehaviour {
	public int _waves;
	public int _enemysWave;
	public float _enemyTime;
	public float _waveTime;
	public bool _hasBoss;
	public int _bulletType;
	// Use this for initialization
	void Start () 
	{
		DontDestroyOnLoad (this);
	}
}
