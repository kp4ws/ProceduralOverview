using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
	[SerializeField] private float speed = 1.0f;
	[SerializeField] private GameObject playerObject;
	[SerializeField] private GameSession3D gameSession;

	private Rigidbody rb;

	Vector3 lookDirection;

	// Start is called before the first frame update
	void Start()
	{
		rb = GetComponent<Rigidbody>();
		playerObject = GameObject.FindGameObjectWithTag("Player");
	}

	// Update is called once per frame
	void Update()
	{
		if (playerObject)
		{
			lookDirection = (playerObject.transform.position - transform.position).normalized;
			rb.AddForce(GetForce());
		}

		if (Input.GetKeyDown(KeyCode.Alpha1))
		{
			gameSession.ToggleAttack();
		}
	}

	private Vector3 GetForce()
	{
		if (gameSession.IsAttacking())
		{
			return lookDirection* speed;
		}
		else
		{
			return Vector3.zero;
		}
	}
}
