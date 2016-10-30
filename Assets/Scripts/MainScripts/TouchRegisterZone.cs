using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class TouchRegisterZone : MonoBehaviour, IPointerDownHandler{

	public TowerManager TM;

	public void OnPointerDown(PointerEventData data)
	{
		TM.canShot = true;
	}
}
