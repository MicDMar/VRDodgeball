using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateText : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public void ChangeText(LeverInfo info)
	{
		GetComponent<Text>().text = info.EnabledCount.ToString();
	}
}
