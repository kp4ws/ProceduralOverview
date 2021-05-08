using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectController : MonoBehaviour
{
	private int destroyPosition = -50;

    void Update()
    {
        if(transform.position.z < destroyPosition)
		{
			Destroy(gameObject);
		}
    }
}
