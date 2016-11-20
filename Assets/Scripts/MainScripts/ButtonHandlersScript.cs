using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ButtonHandlersScript : MonoBehaviour {

	public string sceneName;
	public DataSender DS;

	void Start(){
		DS = GameObject.FindObjectOfType<DataSender>();
	}
	public void NextLevel (){
		DS.level++;
		LoadScene ();

	}

	public void LoadScene(){
		SceneManager.LoadScene (sceneName);
	}

}
