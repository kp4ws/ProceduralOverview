using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerySimpleAlgorithm : MonoBehaviour
{
	public GameObject spawnObject;

	// Start is called before the first frame update
    void Start()
    {
		Instantiate(spawnObject, new Vector3(0, 0, 0), spawnObject.transform.rotation);
    }
}
