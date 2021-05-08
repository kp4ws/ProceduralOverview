using UnityEngine;

[RequireComponent(typeof(MeshRenderer), typeof(MeshFilter))]
public class MeshGenerator : MonoBehaviour
{
	private Mesh mesh;
	private MeshFilter meshFilter;
	private MeshRenderer meshRenderer;

	private Vector3[] vertices;
	private int[] triangles;

	[SerializeField] private int xSize = 20;
	[SerializeField] private int zSize = 20;
	[SerializeField] private float scale = 0.1f;

	private void Awake()
	{
		meshFilter = GetComponent<MeshFilter>();
		meshRenderer = GetComponent<MeshRenderer>();

		mesh = meshFilter.mesh;
	}

	private void Start()
	{
		//Gives the mesh a material. You can also do this in the inspector
		meshRenderer.sharedMaterial = new Material(Shader.Find("Standard"));

		CreateMesh();
		GenerateMesh();
	}

	private void CreateMesh()
	{
		vertices = new Vector3[(xSize + 1) * (zSize + 1)];

		for (int index = 0, z = 0; z <= zSize; z++)
		{
			for (int x = 0; x <= xSize; x++)
			{
				float y = Mathf.PerlinNoise(x * scale, z * scale) * 10f;
				vertices[index] = new Vector3(x, y, z);
				index++;
			}
		}


		int vert = 0;
		int tris = 0;
		triangles = new int[xSize * zSize * 6];

		for (int z = 0; z < zSize; z++)
		{
			for (int x = 0; x < xSize; x++)
			{

				//Bottom Left Trianglge
				triangles[tris + 0] = vert + 0;
				triangles[tris + 1] = vert + xSize + 1;
				triangles[tris + 2] = vert + 1;

				//Top Right Triangle
				triangles[tris + 3] = vert + 1;
				triangles[tris + 4] = vert + xSize + 1;
				triangles[tris + 5] = vert + xSize + 2;

				vert++;
				tris += 6;
			}
			vert++;
		}
	}

	private void GenerateMesh()
	{
		mesh.Clear();

		mesh.vertices = vertices;
		mesh.triangles = triangles;

		//Automatic process to calculate the normals. You can do this step manually but is usually done automatically.
		mesh.RecalculateNormals();
	}

	/*
	private void OnDrawGizmos()
	{
		if (vertices == null)
		{
			return;
		}

		for (int i = 0; i < vertices.Length; i++)
		{
			Gizmos.DrawSphere(vertices[i], .1f);
		}
	}
	*/
}
