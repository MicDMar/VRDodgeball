using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Being : MonoBehaviour
{
	protected bool alive = true;
	public bool Alive
	{
		get { return alive; }
		set { alive = value; }
	}

	[SerializeField] private float startingHealth = 120;

	[SerializeField] private float maxHealth = 120;

	protected float health = 120;
	public float Health
	{
		get { return health; }
	}

	public UnityEvent OnDeath;

	void Start()
	{
		health = startingHealth;
	}

	void Update ()
	{
		
		if (health <= 0)
		{
			alive = false;
			OnDeath.Invoke();
		}
	}

	public void TakeDamage(float damage = 40)
	{
		// Eventually damage could be a type with types and modifiers
		if (health <= 0)
		{
			return;
		}

		health -= damage;
	}

	public void Heal(float amount)
	{
		health += amount;
		if (health > maxHealth)
			health = maxHealth;

	}
	
	public void Die()
	{
		alive = false;
		health = 0;
	}

}
