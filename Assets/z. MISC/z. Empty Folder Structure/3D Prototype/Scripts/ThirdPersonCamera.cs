using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
	[SerializeField] private Vector3 offset;
	private GameObject player;
	private Camera camera;

	private void Start()
	{
		player = GameObject.FindGameObjectWithTag("Player");
		camera = GetComponent<Camera>();
		transform.rotation = Quaternion.Euler(10, 0, 0);
	}

	void Update()
	{
		if (player)
		{
			transform.position = player.transform.position + offset;
		}
	}
}
