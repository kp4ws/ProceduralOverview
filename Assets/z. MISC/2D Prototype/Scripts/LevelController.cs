/*
* Copyright (c) Kp4ws
*
*/
using UnityEngine;
using System.Collections.Generic;

public class LevelController : MonoBehaviour
{
	[SerializeField] private GameObject[] blockTypes;
	[SerializeField] private GameObject nextWaveCanvas;

	private int countdownTimer = 3;
	private int breakableBlocks;
	private int wave = 0;
	private List<Vector2> spawnPositions = new List<Vector2>();

	//Map Positions
	private int minX = 1;
	private int maxX = 21;
	private int minY = 4;
	private int maxY = 15;


	private void Start()
	{
		GenerateBlocks();
	}

	public void GenerateBlocks()
	{
		for (int i = 0; i < getMaxBlocks(); i++)
		{
			int selectedBlock = Random.Range(0, blockTypes.Length);

			Vector2 spawnPos = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));

			if (!spawnPositions.Contains(spawnPos))
			{
				spawnPositions.Add(spawnPos);

				GameObject block = Instantiate(blockTypes[selectedBlock], spawnPos, Quaternion.identity);

			block.GetComponent<SpriteRenderer>().color = new Color(Random.Range(0.8f, 1f), Random.Range(0.8f, 1f), Random.Range(0.8f, 1f), 1f);
			}
		}
	}

	private int getMaxBlocks()
	{
		switch (wave)
		{

			case 0:
				return 10;
			case 1:
				return 32;
			case 2:
				return 54;
			case 3:
				return 76;
			case 4:
				return 98;
			case 5:
				return 120;
			case 6:
				return 142;
			case 7:
				return 162;
			case 8:
				return 182;
			case 9:
				return 208;
			default:
				return 500;
		}
	}

	public void CountBlocks()
	{
		breakableBlocks++;
	}

	public void BlockDestroyed()
	{
		if ((--breakableBlocks) == 0)
		{
			wave++;
			FindObjectOfType<BallController>().ResetBall();
			nextWaveCanvas.SetActive(true);
		}
	}
}

