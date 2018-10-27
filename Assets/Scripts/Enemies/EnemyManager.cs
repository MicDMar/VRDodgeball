using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{

	public Transform spawnPoint;
	public EnemySearchZone zone;
	public GameObject enemyPrefab;
	public int startingEnemyCount = 5;

	private List<GameObject> enemies;
	// Use this for initialization
	void Start () {
		enemies = new List<GameObject>();
		for (int i = 0; i < startingEnemyCount; ++i)
		{
			addEnemy();
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public bool HasEnemies()
	{
		return enemies.Count > 0;
	}

	void addEnemy()
	{
		var enemy = GameObject.Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);
		enemy.GetComponent<Wanderer>().manager = this;
		enemies.Add(enemy);
	}

	public void removeEnemy(GameObject enemy)
	{
		enemies.Remove(enemy);
		Destroy(enemy);
	}
}
