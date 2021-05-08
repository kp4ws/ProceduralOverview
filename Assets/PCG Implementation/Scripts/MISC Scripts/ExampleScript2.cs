using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExampleScript2 : MonoBehaviour
{
	//"Bobbing" animation from 1D Perlin noise

	//Range over which height varies
	float heightScale = 5.0f;

	//Distance covered per second along X axis of Perlin plane
	float xScale = 5.0f;

	private void Update()
	{
		float height = heightScale * Mathf.PerlinNoise(Time.time * xScale, 0.0f);
		Vector3 pos = transform.position;
		pos.y = height;
		transform.position = pos;
	}
}
