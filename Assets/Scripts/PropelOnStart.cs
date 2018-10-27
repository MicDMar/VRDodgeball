using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropelOnStart : MonoBehaviour
{

	public float forceMultiplier = 2.0f;
	// Use this for initialization
	void Start () {
		
		var body = GetComponent<Rigidbody>();
		body.velocity *= forceMultiplier;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
