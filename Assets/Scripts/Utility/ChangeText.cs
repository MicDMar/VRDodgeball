using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.UI;

public class ChangeText : MonoBehaviour 
{

	void Start() 
	{
		
	}
	
	void Update() 
	{
		
	}

	public void Change(String text)
	{
		GetComponent<Text>().text = text;
	}

	public void Change(int text)
	{
		GetComponent<Text>().text = text.ToString();
	}
}
