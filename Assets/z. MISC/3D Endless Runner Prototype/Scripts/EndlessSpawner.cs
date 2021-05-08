using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndlessSpawner : MonoBehaviour
{
	[SerializeField] private GameObject objectPrefab;
	private bool autoSpawn = true;

	private const float Y_SPAWN = 0.6f;
	private const float Z_SPAWN = 40.0f;

	private const float MIN_X = -7.5f;
	private const float MAX_X = 7.5f;

	private float maxSize = 10;
	private float minSize = 1;

	private float spawnDelay = 0.5f;

	void Start()
	{
		StartCoroutine(SpawnProcess());
	}

	private IEnumerator SpawnProcess()
	{
		while (autoSpawn)
		{
			GenerateObject();
			yield return new WaitForSeconds(spawnDelay);
		}
	}

	public void GenerateObject()
	{
		Vector3 spawnPos = new Vector3(Random.Range(MIN_X, MAX_X), Y_SPAWN, Z_SPAWN);
		GameObject objectHandle = Instantiate(objectPrefab, spawnPos, Quaternion.identity);

		Vector3 objectSize = new Vector3(Random.Range(minSize, maxSize), 10, Random.Range(minSize, maxSize));
		objectHandle.transform.localScale = objectSize;
	}
}
