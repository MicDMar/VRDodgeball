using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

	public EnemyManager enemyManager;
	public GameObject player;

	[SerializeField]
	public Counter enemyCount;

	public int StartingEnemyCount = 3;

	// Use this for initialization
	void Start () {
		DontDestroyOnLoad(gameObject);
		SceneManager.sceneLoaded += updateEnemyManager;
	}

	void updateEnemyManager(Scene scene, LoadSceneMode mode)
	{
		enemyManager = GameObject.FindObjectOfType<EnemyManager>();
		if (enemyManager != null)
		{
			enemyManager.startingEnemyCount = StartingEnemyCount;
		}

		player = GameObject.FindWithTag("Player");
		player.GetComponent<Being>().OnDeath.AddListener(Lose);
	}
	
	// Update is called once per frame
	void Update()
	{
		if (enemyManager != null) {
			if (!enemyManager.HasEnemies())
			{
				Win();
			}
		}

		if (player != null)
		{
			if (player.GetComponent<Being>().Alive == false)
			{
				Lose();
			}
		}

	}

	public void Win()
	{
		// Dirty fix
		StartingEnemyCount = 5;
		SceneManager.LoadScene("win");
	}

	public static void Lose()
	{
		SceneManager.LoadScene("lose");
	}

	public void StartGame()
	{

		if (enemyCount != null)
		{
			StartingEnemyCount = enemyCount.Count;
		}
		SceneManager.LoadScene("newmain");
	}
}

