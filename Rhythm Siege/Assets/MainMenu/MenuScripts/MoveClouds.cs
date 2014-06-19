using UnityEngine;
using System.Collections;

public class MoveClouds : MonoBehaviour {
	public Transform pointTest;
	// Use this for initialization
	public Vector3 pointB;
	private float time = 3f;
	public float speed;
	IEnumerator Start()
	{
		pointB = pointTest.transform.position;
		var pointA = transform.position;
		while (true) {
			yield return StartCoroutine(MoveObject(transform, pointA, pointB, time));
			yield return StartCoroutine(MoveObject(transform, pointB, pointA, time));
		}
	}
	
	IEnumerator MoveObject(Transform thisTransform, Vector3 startPos, Vector3 endPos, float time)
	{
		time = Random.Range(1,5);
		var i= 0.0f;
		var rate= speed/time;
		while (i < 1.0f) {
			i += Time.deltaTime * rate;
			thisTransform.position = Vector3.Lerp(startPos, endPos, i);
			yield return null; 
		}
	}
}
