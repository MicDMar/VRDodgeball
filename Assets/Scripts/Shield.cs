using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NewtonVR;

public class Shield : MonoBehaviour
{

	public NVRButtons activateButton;
	public GameObject shield;
	public NVRHand hand;
	private GameObject clone;
	private Collider collider;

	public bool StartEnabled = false;

	private bool shieldEnabled;

	public void Enable()
	{
		if (!shieldEnabled)
		{
			clone = Instantiate(shield, transform).gameObject;
			clone.transform.localPosition = Vector3.zero;
			shieldEnabled = true;
		}
	}

	public void Disable()
	{
		if (shieldEnabled)
		{
			Destroy(clone);
			shieldEnabled = false;
		}
	}

	public void Toggle()
	{
		if (shieldEnabled)
		{
			Disable();
		}
		else
		{
			Enable();
		}
	}

	void Start()
	{
		hand = GetComponent<NVRHand>();
		if (StartEnabled)
		{
			Enable();
		}
	}

	void Update()
	{
		if (hand.Inputs[activateButton].PressDown)
		{
			Toggle();
		}
	}
}
