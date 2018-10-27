using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPrefabOnEvent : MonoBehaviour
{
	public GameObject prefab;

	void Start() 
	{
		
	}
	
	void Update() 
	{
		
	}

	public void Spawn()
	{
		var item = GameObject.Instantiate(prefab);
		item.transform.position = transform.position;
		item.transform.localScale = transform.localScale;
		item.transform.rotation = transform.rotation;
	}
}
