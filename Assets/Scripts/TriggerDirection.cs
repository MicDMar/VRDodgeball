using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerDirection : MonoBehaviour
{
	// OnTriggerUp and OnTriggerDown require the other object to have a rigidbody
	public UnityEvent OnTriggerUp;
	public UnityEvent OnTriggerDown;
	public UnityEvent OnTrigger;
	
	void Start() 
	{
		//OnTrigger.AddListener(delegate { Debug.Log("Triggered"); });
		//OnTriggerUp.AddListener(delegate { Debug.Log("Up Triggered"); });
		//OnTrigger.AddListener(delegate { Debug.Log("Down Triggered"); });
	}
	
	void Update () {
		
	}

	private void OnTriggerEnter(Collider other)
	{
		OnTrigger.Invoke();
		// Determine direction moving
		var rigidbody = other.gameObject.GetComponent<Rigidbody>();

		if (rigidbody != null)
		{
			if (rigidbody.velocity.y > 0)
			{
				OnTriggerUp.Invoke();
			}
			else if (rigidbody.velocity.y < 0)
			{
				OnTriggerDown.Invoke();
			}
		}
	}

}
