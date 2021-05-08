using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatFloor : MonoBehaviour
{
	private Vector3 startPosition;
	private int repeatLength = 50;

    void Start()
    {
		startPosition = transform.position;
    }

    void Update()
    {
		if (transform.position.z < startPosition.z - repeatLength)
		{
			transform.position = startPosition;
		}
	}
}
