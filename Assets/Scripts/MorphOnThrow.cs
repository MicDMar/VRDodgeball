using System.Collections;
using System.Collections.Generic;
using NewtonVR;
using UnityEngine;


public class MorphOnThrow : MonoBehaviour
{

	public GameObject morphObject;


	void Start()
	{
		var interactable = GetComponent<NVRInteractableItem>();
		interactable.OnEndInteraction.AddListener(Launch);
	}
	
	void Update() 
	{
		
	}

	void Launch()
	{
		// Align forward
		var newObject = Instantiate(morphObject);

		var filter = GetComponent<MeshFilter>();
		var collider = GetComponent<SphereCollider>();
		var renderer = GetComponent<MeshRenderer>();
		
		Destroy(filter);
		Destroy(collider);
		Destroy(renderer);

		newObject.transform.position = transform.position;
		newObject.transform.rotation = transform.rotation;
		newObject.transform.localScale = transform.localScale;

		var rigidbody = GetComponent<Rigidbody>();
		var newRigidbody = newObject.GetComponent<Rigidbody>();

		newRigidbody.velocity = rigidbody.velocity;
		newRigidbody.angularVelocity = rigidbody.angularVelocity;
		
	}

}
