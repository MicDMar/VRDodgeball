using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Xml.Schema;
using NewtonVR;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class LeverEvent : UnityEvent<LeverInfo> {}

public class LeverInfo
{
	private int enabledCount;

	public int EnabledCount
	{
		get { return enabledCount; }
		set { enabledCount = value; }
	}
}
public class LeverInfoHandler : MonoBehaviour
{
	public NVRLever lever;

	public LeverEvent OnLeverEngage;

	private LeverInfo info;
	
	public int activationAmount = -1;

	public UnityEvent onActivation;

	// Use this for initialization
	void Start ()
	{
		lever = lever ?? GetComponent<NVRLever>();
		
		info = new LeverInfo();
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log(lever.LeverEngaged);
		if (lever.LeverEngaged)
		{
			leverEngaged();	
		}
	}

	void leverEngaged()
	{
		// Set up info
		info.EnabledCount++;	
		
		OnLeverEngage.Invoke(info);

		if (info.EnabledCount == activationAmount)
		{
			onActivation.Invoke();
		}
	}
}
