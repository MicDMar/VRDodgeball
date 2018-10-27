using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class CountEvent : UnityEvent<int> { }

[System.Serializable]
public class Counter : MonoBehaviour
{

	public int StartingCount = 0;
	public CountEvent OnAwake;
	public CountEvent OnChange;

	public int Count { get; private set; }

	void Start()
	{
		Count = StartingCount;
		OnAwake.Invoke(Count);
	}
	
	void Update() 
	{

	}

	public void Increment(int amount = 1)
	{
		Count += amount;
		OnChange.Invoke(Count);
	}

	public void Decrement(int amount = 1)
	{
		Count -= amount;
		OnChange.Invoke(Count);
	}


}
