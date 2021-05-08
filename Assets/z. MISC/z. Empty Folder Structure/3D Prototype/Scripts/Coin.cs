using UnityEngine;
using TMPro;

public class Coin : MonoBehaviour
{
	[SerializeField] private float rotateSpeed = 0.8f;

	private void Start()
	{
		FindObjectOfType<Spawner>().IncrementCoinCount();
	}

	private void Update()
	{
		transform.Rotate(0, rotateSpeed, 0, Space.World);
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{
			FindObjectOfType<GameSession3D>().IncrementScore();
			Destroy(gameObject);
			FindObjectOfType<Spawner>().CoinDestroyed();
		}
	}
}
