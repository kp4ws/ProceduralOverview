using UnityEngine;

public class TileGenerator : MonoBehaviour
{
	[SerializeField] private NoiseGenerator noiseGenerator;
	[SerializeField] private TerrainType[] terrainTypes;
	[SerializeField] private AnimationCurve heightCurve;
	[SerializeField] private Wave[] waves;

	[SerializeField] private float heightMultiplier = 5;
	[SerializeField] private float scale = 1;

	private MeshRenderer meshRenderer;
	private MeshFilter meshFilter;
	private MeshCollider meshCollider;

	private void Start()
	{
		meshRenderer = GetComponent<MeshRenderer>();
		meshFilter = GetComponent<MeshFilter>();
		meshCollider = GetComponent<MeshCollider>();
		noiseGenerator = FindObjectOfType<NoiseGenerator>();

		GenerateTile();
	}

	private void GenerateTile()
	{
		Vector3[] meshVertices = meshFilter.mesh.vertices;
		int tileWidth = (int)Mathf.Sqrt(meshVertices.Length);

		//Since the plane is a square, the height will equal the width
		int tileHeight = tileWidth;


		float xOrigin = -gameObject.transform.position.x;
		float yOrigin = -gameObject.transform.position.y;


		float[,] heightMap = noiseGenerator.CreateNoiseMap(tileWidth, tileHeight, xOrigin, yOrigin, scale, waves);

		Texture2D tileTexture = BuildTexture(heightMap);
		meshRenderer.material.mainTexture = tileTexture;
	}

	private Texture2D BuildTexture(float[,] heightMap)
	{
		int tileWidth = heightMap.GetLength(0);
		int tileHeight = heightMap.GetLength(1);

		Color[] colorMap = new Color[tileWidth * tileHeight];
		for (int y = 0; y < tileHeight; y++)
		{
			for (int x = 0; x < tileWidth; x++)
			{
				int colorIndex = y * tileWidth + x;
				float height = heightMap[y, x];

				TerrainType terrainType = ChooseTerrainType(height);

				colorMap[colorIndex] = terrainType.color;
			}
		}

		Texture2D tileTexture = new Texture2D(tileWidth, tileHeight);

		//Makes the texture not repeat (which is by default)
		tileTexture.wrapMode = TextureWrapMode.Clamp;

		//Removes the blurriness from the texture. Default is Bilinear
		//ileTexture.filterMode = FilterMode.Point;

		tileTexture.SetPixels(colorMap);
		tileTexture.Apply();

		UpdateMeshVertices(heightMap);

		return tileTexture;
	}

	private void UpdateMeshVertices(float[,] heightMap)
	{
		int tileWidth = heightMap.GetLength(0);
		int tileHeight = heightMap.GetLength(1);

		Vector3[] meshVertices = meshFilter.mesh.vertices;

		int vertexIndex = 0;
		for (int y = 0; y < tileHeight; y++)
		{
			for (int x = 0; x < tileWidth; x++)
			{
				float height = heightMap[y, x];

				Vector3 vertex = meshVertices[vertexIndex];

				//float correctedHeight = height < 0.4f ? 0 : height * heightMultiplier;

				meshVertices[vertexIndex] = new Vector3(vertex.x, heightCurve.Evaluate(height), vertex.z);

				vertexIndex++;
			}
		}

		meshFilter.mesh.vertices = meshVertices;
		meshFilter.mesh.RecalculateBounds();
		meshFilter.mesh.RecalculateNormals();

		meshCollider.sharedMesh = meshFilter.mesh;
	}

	private TerrainType ChooseTerrainType(float height)
	{
		foreach (TerrainType t in terrainTypes)
		{
			if (height < t.height)
			{
				return t;
			}
		}

		return terrainTypes[terrainTypes.Length - 1];
	}
}

[System.Serializable]
public class TerrainType
{
	public string name;
	public float height;
	public Color color;
}
