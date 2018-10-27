using System.Collections;
using System.Collections.Generic;
using NewtonVR;
using UnityEngine;
using UnityEngine.Events;

public class CountEngagements : MonoBehaviour
{

	public NVRLever lever;
	private int count;
	public int activationAmount = -1;

	public UnityEvent onActivation;

	public int Count
	{
		get { return count; }
	}
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (lever.LeverEngaged)
		{
			count++;
			if (count == activationAmount)
			{
				onActivation.Invoke();
			}
		}
	}
}
