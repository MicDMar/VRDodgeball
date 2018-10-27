using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class DestroyOnNextCollision : MonoBehaviour
{

	public bool Active = false;
	public bool ActivateAfterDelay = true;
	public float delay = 0.1f;

	// Use this for initialization
	void Start ()
	{
		if (ActivateAfterDelay)
			SlowActivate();
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnCollisionEnter(Collision other)
	{
		Debug.Log("Collision!");
		if (Active)
		{
			Debug.Log("Destroying");
			// Dirty 'hack'
			Destroy(gameObject);
		}
	}

	public void SlowActivate()
	{
		StartCoroutine(ActivateAfterTime(delay));
	}

	private IEnumerator ActivateAfterTime(float time)
	{
		yield return new WaitForSeconds(time);
		Active = true;
	}
}
