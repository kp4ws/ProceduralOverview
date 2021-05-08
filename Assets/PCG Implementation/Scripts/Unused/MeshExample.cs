using UnityEngine;

[RequireComponent(typeof(MeshRenderer), typeof(MeshFilter))]
public class MeshExample : MonoBehaviour
{
	[SerializeField] private float xWidth = 1;
	[SerializeField] private float yHeight = 1;
	[SerializeField] private float zLength = 1;

	private Mesh mesh;
	private MeshFilter meshFilter;
	private MeshRenderer meshRenderer;

	private Vector3[] vertices;
	private int[] triangles;

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

		vertices = new Vector3[36]
		{

            #region Front Face
            //Bottom left triangle
            new Vector3(xWidth,0,0),
			new Vector3(0,0,0),
			new Vector3(0,yHeight,0),

            //Top right triangle
            new Vector3(xWidth,0,0),
			new Vector3(0,yHeight,0),
			new Vector3(xWidth,yHeight,0),
            #endregion

            #region Left Face
            //Bottom left triangle
            new Vector3(0,0,0),
			new Vector3(0,0,zLength),
			new Vector3(0,yHeight,zLength),

            //Top right triangle
            new Vector3(0,0,0),
			new Vector3(0,yHeight,zLength),
			new Vector3(0,yHeight,0),
            #endregion

            #region Right Face
            //Bottom left triangle
            new Vector3(xWidth,0,zLength),
			new Vector3(xWidth,0,0),
			new Vector3(xWidth,yHeight,0),

            //Top right triangle
            new Vector3(xWidth,0,zLength),
			new Vector3(xWidth,yHeight,0),
			new Vector3(xWidth,yHeight,zLength),
            #endregion

            #region Back Face
            //Bottom left triangle
            new Vector3(0,0,zLength),
			new Vector3(xWidth,0,zLength),
			new Vector3(xWidth,yHeight,zLength),

            //Top right triangle
            new Vector3(0,0,zLength),
			new Vector3(xWidth,yHeight,zLength),
			new Vector3(0,yHeight,zLength),
            #endregion

            #region Top Face
            //Bottom left triangle
            new Vector3(xWidth,yHeight,0),
			new Vector3(0,yHeight,0),
			new Vector3(0,yHeight,zLength),

            //Top right triangle
            new Vector3(xWidth,yHeight,0),
			new Vector3(0,yHeight,zLength),
			new Vector3(xWidth,yHeight,zLength),
            #endregion

            #region Bottom Face
            //Bottom left triangle
            new Vector3(xWidth,0,zLength),
			new Vector3(0,0,zLength),
			new Vector3(0,0,0),

            //Top right triangle
            new Vector3(xWidth,0,zLength),
			new Vector3(0,0,0),
			new Vector3(xWidth,0,0)
            #endregion
        };

		//vertices are already in clockwise position
		triangles = new int[36]
		{
        //Front Face
        0,1,2,
		3,4,5,

        //Left Face
        6,7,8,
		9,10,11,

        //Right Face
        12,13,14,
		15,16,17,

        //Back Face
        18,19,20,
		21,22,23,

        //Top Face
        24,25,26,
		27,28,29,

        //Bottom Face
        30,31,32,
		33,34,35
		};

		GenerateMesh();
	}

	private void GenerateMesh()
	{
		mesh.Clear();
		//mesh.normals = normals;
		//mesh.uv = newUV;

		mesh.vertices = vertices;
		mesh.triangles = triangles;

		//Automatic process to calculate the normals. You can do this step manually but is usually done automatically.
		mesh.RecalculateNormals();
	}
}
