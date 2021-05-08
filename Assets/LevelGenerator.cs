using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
	[SerializeField] private int maxX = 5;
	[SerializeField] private int maxZ = 5;

	[SerializeField] private int offsetX;
	[SerializeField] private int offsetY;
	[SerializeField] private int offsetZ;

	[SerializeField] private GameObject tile;


	Vector3 tileSize;


	private void Start()
	{
		tileSize = tile.GetComponent<MeshRenderer>().bounds.size;
		CreateWorld();
	}

	private void CreateWorld()
	{
		for (int z = 0; z < maxZ; z++)
		{
			for (int x = 0; x < maxX; x++)
			{
				Instantiate(tile, new Vector3((x * tileSize.x) + offsetX, offsetY, (z * (tileSize.z) + offsetZ)), Quaternion.identity);
			}
		}

	}
}
