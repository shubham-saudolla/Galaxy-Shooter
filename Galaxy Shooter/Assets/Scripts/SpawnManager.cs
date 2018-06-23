/*
Copyright (c) Shubham Saudolla
https://github.com/shubham-saudolla
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
	[SerializeField]
	private GameObject enemyShipPrefab;
	[SerializeField]
	private GameObject[] powerUps;

	void Start ()
	{
		StartCoroutine(EnemySpawnRoutine());
		StartCoroutine(PowerupSpawnRoutine());
	}
	
	//coroutine to spawn an enemy every five seconds
	IEnumerator EnemySpawnRoutine()
	{
		while(true)
		{
			Instantiate(enemyShipPrefab, new Vector3(Random.Range(-7f, 7f), 7, 0), Quaternion.identity);
			yield return new WaitForSeconds(5.0f);
		}
	}

	IEnumerator PowerupSpawnRoutine()
	{
		while(true)
		{
			int randomPowerup = Random.Range(0, 3);
			Instantiate(powerUps[randomPowerup], new Vector3(Random.Range(-7f, 7f), 7, 0), Quaternion.identity);
			yield return new WaitForSeconds(5.0f);
		}
	}
}
