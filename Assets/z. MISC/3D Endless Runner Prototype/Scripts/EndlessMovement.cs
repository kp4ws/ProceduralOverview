using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndlessMovement : MonoBehaviour
{
	[SerializeField] private float speed = 20f;

	private void Update()
	{
		transform.Translate(Vector3.back * Time.deltaTime * speed);
	}
}
