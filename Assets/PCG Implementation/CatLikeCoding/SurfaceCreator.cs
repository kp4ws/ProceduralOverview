using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class SurfaceCreator : MonoBehaviour
{
	[Range(1, 200)] [SerializeField] private int resolution = 10;
	private Mesh mesh;

	//Keeps track of the resolution so the grid is only changed when the resolution has changed
	private int currentResolution;

	private void OnEnable()
	{
		if (mesh == null)
		{
			mesh = new Mesh();
			mesh.name = "Surface Mesh";
			GetComponent<MeshFilter>().mesh = mesh;
		}
		Refresh();
	}

	public void Refresh()
	{
		if (resolution != currentResolution)
		{
			CreateGrid();
		}
	}

	private void CreateGrid()
	{
		currentResolution = resolution;
		mesh.Clear();

		Vector3[] vertices = new Vector3[(resolution + 1) * (resolution + 1)]; //OR Mathf.Pow((resolution +1), 2);
		Vector2[] uv = new Vector2[vertices.Length];

		//TODO: Not sure what this variable is yet?
		float stepSize = 1f / resolution;

		for (int v = 0, y = 0; y < resolution; y++)
		{
			for (int x = 0; x < resolution; x++)
			{
				//We need to offset the quad by -0.5f to center it on the origin
				vertices[v] = new Vector3(x * stepSize - 0.5f, y * stepSize - 0.5f);
				uv[v] = new Vector2(x * stepSize, y * stepSize);
			}
		}

		mesh.vertices = vertices;
		mesh.uv = uv;

		int[] triangles = new int[resolution * resolution * 6];

		for (int t = 0, v = 0, y = 0; y <= resolution; y++, v++)
		{
			for (int x = 0; x < resolution; x++, v++, t+=6)
			{
				triangles[t] = v;
				triangles[t + 1] = v + resolution + 1;
				triangles[t + 2] = v + 1;
				triangles[t + 3] = v + 1;
				triangles[t + 4] = v + resolution + 1;
				triangles[t + 5] = v + resolution + 1;
			}
		}

		mesh.triangles = triangles;
	}


	
}