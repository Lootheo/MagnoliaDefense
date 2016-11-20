using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class UpgradeCardSwitchScript : MonoBehaviour {
	public GameObject leftCard;
	public GameObject rightCard;
	public GameObject middleCard;


	// Use this for initialization
	void Start () {
	
	}

	//Switch middle card with right card
	public void SwitchRight(){

		//Get recttransforms
		RectTransform middleRT = middleCard.GetComponent<RectTransform> ();
		RectTransform rightRT = rightCard.GetComponent<RectTransform> ();

		//Assign local variables
		Vector2 tempAnchor = rightRT.anchoredPosition;
		Vector3 tempPosition = rightRT.position;
		Vector3 tempScale = rightRT.localScale;



		//Right goes middle
		rightRT.anchoredPosition = middleRT.anchoredPosition;
		rightRT.position = middleRT.position;
		rightRT.localScale = middleRT.localScale;

		//Middle Goes Right
		middleRT.anchoredPosition= tempAnchor;
		middleRT.position = tempPosition;
		middleRT.localScale = tempScale;


		//Switch Game Object Reference
		GameObject tempGO = rightRT.gameObject;
		rightCard = middleCard;
		middleCard = tempGO;
		middleCard.transform.SetAsLastSibling ();




	}
	//Switch middle card with left card
	public void SwitchLeft(){


		//Get recttransforms
		RectTransform middleRT = middleCard.GetComponent<RectTransform> ();
		RectTransform leftRT = leftCard.GetComponent<RectTransform> ();

		//Assign local variables
		Vector2 tempAnchor = leftRT.anchoredPosition;
		Vector3 tempPosition = leftRT.position;
		Vector3 tempScale = leftRT.localScale;



		//left goes middle
		leftRT.anchoredPosition = middleRT.anchoredPosition;
		leftRT.position = middleRT.position;
		leftRT.localScale = middleRT.localScale;

		//Middle Goes left
		middleRT.anchoredPosition= tempAnchor;
		middleRT.position = tempPosition;
		middleRT.localScale = tempScale;


		//Switch Game Object Reference
		GameObject tempGO = leftRT.gameObject;
		leftCard = middleCard;
		middleCard = tempGO;
		middleCard.transform.SetAsLastSibling ();

	}

	// Update is called once per frame
	void Update () {
	
	}
}
