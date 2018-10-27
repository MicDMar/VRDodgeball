using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowOverTime : MonoBehaviour
{

	public float time = 0.5f;
	public Vector3 desiredScale = new Vector3(2.0f, 2.0f, 2.0f);
	
	// Use this for initialization
	void Start ()
	{
		StartCoroutine(growInSize());
		Debug.Log(transform.localScale);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	private IEnumerator growInSize()
	{
		Debug.Log("Growing");
		//Vector3 originalScale = transform.localScale;
		Vector3 originalScale = transform.localScale;

		float currentTime = 0.0f;

		do
		{
			transform.localScale = Vector3.Lerp(originalScale, desiredScale, currentTime / time);
			currentTime += Time.deltaTime;
			Debug.Log(currentTime);
			Debug.Log(transform.localScale);
			yield return null;
		} while (currentTime <= time);

	}
}
