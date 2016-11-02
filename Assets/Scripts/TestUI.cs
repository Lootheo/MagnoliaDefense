using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;

public class TestUI : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {
	public delegate void MyDetectorType(GameObject _currentPage, GameObject _nextPage);
	public delegate void NextPage(GameObject _currentPage, GameObject _nextPage);
	public delegate int CurrentIndex();
	public MyDetectorType _Next;
	public MyDetectorType _Prev;
	public CurrentIndex DetectorType2;
	public List<GameObject> _Pages = new List<GameObject>();
	public int _index;
	Vector2 ActualPosition;
	bool IsHorizontal;
	RectTransform TRT;
	float ToleranceDist;
	public Vector2 StartPoint, EndPoint;

	void Start()
	{
		TRT = GetComponent<RectTransform>();
		ToleranceDist = TRT.sizeDelta.x * 0.3f;
	}

	public void OnPointerDown(PointerEventData _data)
	{
		StartPoint = _data.position;
	}

	public void OnPointerUp(PointerEventData _data)
	{
		EndPoint = _data.position;
		if(IsHorizontal)
		{
			if(StartPoint.x-_data.position.x>ToleranceDist)
			{
				_Next(_Pages[_index-1], _Pages[_index]);
			}
			else if(_data.position.x-StartPoint.x>ToleranceDist)
			{
				if(_Pages.Count>1)
				{
					_Prev(_Pages[_index+1], _Pages[_index]);
				}
			}
		}
		else
		{
			if(StartPoint.y-_data.position.y>ToleranceDist)
			{
				_Next(_Pages[_index-1], _Pages[_index]);
			}
			else if(_data.position.y-StartPoint.y>ToleranceDist)
			{
				if(_Pages.Count>1)
				{
					_Prev(_Pages[_index+1], _Pages[_index]);
				}
			}
		}
	}

	public void SetDetector(bool _Horizontal)
	{
		IsHorizontal = _Horizontal;
		if(_Horizontal)
		{
			_Next = new MyDetectorType(SlidePageLeft);
			_Prev = new MyDetectorType(SlidePageRight);
		}
		else
		{
			_Next = new MyDetectorType(SlidePageUp);
			_Prev = new MyDetectorType(SlidePageDown);
		}
	}

	public void SlidePageLeft(GameObject _currentPage, GameObject _nextPage)
	{
		RectTransform _currentRect = _currentPage.GetComponent<RectTransform>();
		RectTransform _nextRect = _nextPage.GetComponent<RectTransform>();
		_nextPage.gameObject.SetActive(true);
		StartCoroutine(MovePageLeft(_currentRect, _nextRect, 0.5f));
	}

	IEnumerator MovePageLeft(RectTransform _currentPage, RectTransform _nextPage, float overTime)
	{
		float startTime = Time.time;
		Vector2 target = new Vector2(-_currentPage.sizeDelta.x,0);
		Vector2 target2 = new Vector2(0, 0);
		while(Time.time < startTime + overTime)
		{
			_currentPage.anchoredPosition = Vector2.Lerp(_currentPage.anchoredPosition, target, (Time.time - startTime)/overTime);
			_nextPage.anchoredPosition = Vector2.Lerp(_nextPage.anchoredPosition, target2, (Time.time - startTime)/overTime);
			yield return null;
		}
		_currentPage.anchoredPosition = target;
		_nextPage.anchoredPosition = target2;
		//_currentPage.gameObject.SetActive(false);
	}

	public void SlidePageRight(GameObject _currentPage, GameObject _prevPage)
	{
		RectTransform _currentRect = _currentPage.GetComponent<RectTransform>();
		RectTransform _prevRect = _prevPage.GetComponent<RectTransform>();
		_prevPage.gameObject.SetActive(true);
		StartCoroutine(MovePageRight(_currentRect, _prevRect, 0.5f));
	}

	IEnumerator MovePageRight(RectTransform _currentPage, RectTransform _prevPage, float overTime)
	{
		float startTime = Time.time;
		Vector2 target = new Vector2(_currentPage.sizeDelta.x,0);
		Vector2 target2 = new Vector2(0, 0);
		while(Time.time < startTime + overTime)
		{
			_currentPage.anchoredPosition = Vector2.Lerp(_currentPage.anchoredPosition, target, (Time.time - startTime)/overTime);
			_prevPage.anchoredPosition = Vector2.Lerp(_prevPage.anchoredPosition, target2, (Time.time - startTime)/overTime);
			yield return null;
		}
		_currentPage.anchoredPosition = target;
		_prevPage.anchoredPosition = target2;
		//_currentPage.gameObject.SetActive(false);
	}

	public void SlidePageUp(GameObject _currentPage, GameObject _nextPage)
	{
		RectTransform _currentRect = _currentPage.GetComponent<RectTransform>();
		RectTransform _nextRect = _nextPage.GetComponent<RectTransform>();
		_nextPage.gameObject.SetActive(true);
		StartCoroutine(MovePageUp(_currentRect, _nextRect, 0.5f));
	}

	IEnumerator MovePageUp(RectTransform _currentPage, RectTransform _nextPage, float overTime)
	{
		float startTime = Time.time;
		Vector2 target = new Vector2(0,-_currentPage.sizeDelta.y);
		Vector2 target2 = new Vector2(0, 0);
		while(Time.time < startTime + overTime)
		{
			_currentPage.anchoredPosition = Vector2.Lerp(_currentPage.anchoredPosition, target, (Time.time - startTime)/overTime);
			_nextPage.anchoredPosition = Vector2.Lerp(_nextPage.anchoredPosition, target2, (Time.time - startTime)/overTime);
			yield return null;
		}
		_currentPage.anchoredPosition = target;
		_nextPage.anchoredPosition = target2;
		//_currentPage.gameObject.SetActive(false);
	}

	public void SlidePageDown(GameObject _currentPage, GameObject _prevPage)
	{
		RectTransform _currentRect = _currentPage.GetComponent<RectTransform>();
		RectTransform _prevRect = _prevPage.GetComponent<RectTransform>();
		_prevPage.gameObject.SetActive(true);
		StartCoroutine(MovePageDown(_currentRect, _prevRect, 0.5f));
	}

	IEnumerator MovePageDown(RectTransform _currentPage, RectTransform _prevPage, float overTime)
	{
		float startTime = Time.time;
		Vector2 target = new Vector2(0,_currentPage.sizeDelta.y);
		Vector2 target2 = new Vector2(0, 0);
		while(Time.time < startTime + overTime)
		{
			_currentPage.anchoredPosition = Vector2.Lerp(_currentPage.anchoredPosition, target, (Time.time - startTime)/overTime);
			_prevPage.anchoredPosition = Vector2.Lerp(_prevPage.anchoredPosition, target2, (Time.time - startTime)/overTime);
			yield return null;
		}
		_currentPage.anchoredPosition = target;
		_prevPage.anchoredPosition = target2;
		//_currentPage.gameObject.SetActive(false);
	}
}
