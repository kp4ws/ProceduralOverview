using UnityEngine;

public class Spawner : MonoBehaviour
{
	[SerializeField] private GameObject playerObject;
	[SerializeField] private GameObject enemyObject;
	[SerializeField] private GameObject coinObject;
	[SerializeField] private Vector3 playerSpawn;

	private float spawnRange = 3.0f;
	private float yPosition = 5.2f;
	private int waveNumber = 1;
	private int coinAmount = 0;

	private void Awake()
	{
		Instantiate(playerObject, playerSpawn, Quaternion.identity);
	}

	private void Start()
	{
		SpawnCoins();
		SpawnEnemies();
	}

	private void Update()
	{
		if(Input.GetKeyDown(KeyCode.Alpha2))
		{
			SpawnTons();
		}
	}

	private void SpawnTons()
	{
		for (int i = 0; i < 1000; i++)
		{
			Instantiate(enemyObject, GenerateSpawnPosition(), Quaternion.identity);
		}
	}

	public void IncrementCoinCount()
	{
		coinAmount++;
	}

	public void CoinDestroyed()
	{
		if ((--coinAmount) == 0)
		{
			waveNumber++;
			SpawnEnemies();
			SpawnCoins();
		}
	}

	private void SpawnEnemies()
	{
		for (int i = 0; i < waveNumber; i++)
		{
			Instantiate(enemyObject, GenerateSpawnPosition(), Quaternion.identity);
		}
	}

	private void SpawnCoins()
	{
		for (int i = 0; i < waveNumber*2; i++)
		{
			Instantiate(coinObject, GenerateSpawnPosition(), Quaternion.identity);
		}
	}

	private Vector3 GenerateSpawnPosition()
	{
		Vector3 spawnPosition = new Vector3(Random.Range(-spawnRange, spawnRange), yPosition, Random.Range(-spawnRange, spawnRange));
		return spawnPosition;
	}
}
