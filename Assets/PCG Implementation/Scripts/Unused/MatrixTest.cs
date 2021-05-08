using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatrixTest : MonoBehaviour
{
	[SerializeField] private int maxX = 5;
	[SerializeField] private int maxY = 5;

	[SerializeField] private int offsetX;
	[SerializeField] private int offsetY;

	[SerializeField] private GameObject objectPrefab;


	private float sizeX;
	private float sizeY;


	private void Start()
	{
		sizeX = objectPrefab.transform.localScale.x;
		sizeY = objectPrefab.transform.localScale.y;

		StartCoroutine(CreateLevel());
	}

	private IEnumerator CreateLevel()
	{
		for (int y = 0; y < maxY; y += (int)sizeY)
		{
			for (int x = 0; x < maxX; x += (int)sizeX)
			{
				yield return new WaitForSeconds(0.5f);
				Instantiate(objectPrefab, new Vector3(x + offsetX, y + offsetY, 0), Quaternion.identity);
			}
		}

		Debug.Log("Finished");
	}
}
