using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndlessPlayer : MonoBehaviour
{
	[SerializeField] private float displacementAmount = 3;
	[SerializeField] private float speed = 25f;

	private Vector3 spawnPos;

	private Rigidbody playerRb;

	private void Start()
	{
		playerRb = GetComponent<Rigidbody>();
		spawnPos = transform.position;
	}

	private void Update()
	{
		Movement();
	}

	private void Movement()
	{
		float horizontalInput = Input.GetAxisRaw("Horizontal") * Time.deltaTime * speed;
		float verticalInput = Input.GetAxisRaw("Vertical") * Time.deltaTime * speed;

		var newXPos = Mathf.Clamp(transform.position.x + horizontalInput, spawnPos.x - displacementAmount, spawnPos.x + displacementAmount);
		var newZPos = Mathf.Clamp(transform.position.z + verticalInput, spawnPos.z - 3, spawnPos.z + 6);

		transform.position = new Vector3(newXPos, transform.position.y, newZPos);
	}
}
