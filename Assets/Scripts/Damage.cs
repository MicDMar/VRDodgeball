using System;
using System.Collections;
using System.Collections.Generic;
using NewtonVR;
using UnityEngine;

public class Damage : MonoBehaviour
{

	public bool enabled = false;
	public float damageAmount = 40.0f;
	// Use this for initialization
	void Start ()
	{
		var interactable = GetComponent<NVRInteractableItem>();
		
		interactable.OnEndInteraction.AddListener(onThrown);

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void onPickup()
	{
		enabled = false;
	}
	
	public void onThrown()
	{
		StartCoroutine(enableDamageForTime());
	}

	private IEnumerator enableDamageForTime(float time = 0.5f)
	{
		enabled = true;
		yield return new WaitForSeconds(time);
		enabled = false;
	}

	private void OnCollisionEnter(Collision other)
	{
		if (enabled)
		{
			var being = other.gameObject.GetComponent<Being>();

			if (being != null)
			{
				// Maybe add a random chance for a 'catch'??
				being.TakeDamage(damageAmount);
				Debug.Log(String.Format("Dealing {0} damage to {1}", damageAmount, other.gameObject.name));
				// No Chaining of damage
				enabled = false;
			}
		}
	}
}
