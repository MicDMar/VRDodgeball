using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class Freeze : MonoBehaviour
{
	public bool startFrozen = true;
	public GameObject objectToFreeze;
	public bool Frozen
	{
		get { throw new System.NotImplementedException(); }
		set
		{
			if (value)
			{
				objectToFreeze.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
			}
			else
			{
				objectToFreeze.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
			}
		}
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
