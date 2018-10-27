using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

public class DisplayHealth : MonoBehaviour
{

	public Being healthtarget;
	
	void Start() 
	{
		
	}
	
	void Update()
	{
		getHealth();
	}

	public void getHealth()
	{
		GetComponent<Text>().text = ("Health: " + healthtarget.Health/40).ToString();
	}
}
