using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(Collider))]
public class EnemySearchZone : MonoBehaviour {

	private List<GameObject> availableBalls;
	
	// Use this for initialization
	void Start () {
		availableBalls = new List<GameObject>();	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	
	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "ball")
		{
			Debug.Log(String.Format("Ball {0} coming in", other.name));
			availableBalls.Add(other.gameObject);
			Debug.Log(availableBalls.ToString());
		}	
	}

	private void OnTriggerExit(Collider other)
	{
		if (other.gameObject.tag == "ball")
		{
			RemoveBall(other.gameObject);
		}
	}

	public void RemoveBall(GameObject ball)
	{
		Debug.Log(String.Format("Ball {0} leaving", ball.name));
		availableBalls.Remove(ball);
	}

	public GameObject getRandomBall()
	{
		if (availableBalls.Count > 0)
		{
			foreach (var ball in availableBalls)
			{
				ball.GetComponent<Ball>().taken = true;
				availableBalls.Remove(ball);
				return ball;
			}
		}

		return null;
	}
}
