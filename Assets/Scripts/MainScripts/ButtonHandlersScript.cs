using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ButtonHandlersScript : MonoBehaviour {

	public string sceneName;

	public void LoadScene(){
		SceneManager.LoadScene (sceneName);
	}

}
