using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using NewtonVR;
using UnityEngine;

[RequireComponent(typeof(NVRInteractableItem))]
[RequireComponent(typeof(Rigidbody))]
public class PropelOnThrow : MonoBehaviour
{

	public bool enabled = true;
	public float forceMultiplier = 1.0f;

	// Use this for initialization
	void Start ()
	{
		var interactable = GetComponent<NVRInteractableItem>();
		interactable.OnEndInteraction.AddListener(launch);
	}

	void launch()
	{
		if (enabled)
		{
			var body = GetComponent<Rigidbody>();
			body.velocity *= forceMultiplier;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
