using System.Collections;
using UnityEngine;

public class Generator : MonoBehaviour
{
	[Header("Testing Purposes")] [SerializeField] private bool autoGenerate = true;

	//width and height of texture in pixels
	[SerializeField] private int pixelWidth = 300;
	[SerializeField] private int pixelHeight = 300;

	private int tempWidth;
	private int tempHeight;

	//origin of sampled area in the plane
	[SerializeField] private float xOrigin = 1f;
	[SerializeField] private float yOrigin = 1f;

	//Number of cycles of the basic noise pattern that are repeated over the width and height of the texture
	[SerializeField] private float scale = 20.0f;

	private Texture2D noiseTexture;
	private Color[] pixels;
	private Renderer textureRenderer;

	private void Start()
	{
		textureRenderer = GetComponent<Renderer>();
		DrawMap();
	}

	private void Update()
	{
		/*
		if (tempWidth != pixelWidth || tempHeight != pixelHeight)
		{
			if (pixelWidth > 0 && pixelHeight > 0)
			{
				tempWidth = pixelWidth;
				tempHeight = pixelHeight;
				UpdateTexture();
			}
		}
		else if (autoGenerate)
		{
			ApplyChanges();
		}
		*/
	}

	private void DrawMap()
	{
		noiseTexture = new Texture2D(pixelWidth, pixelHeight);
		pixels = new Color[noiseTexture.width * noiseTexture.height];

		//For each pixel in the texture
		for (int y = 0; y < noiseTexture.height; y++)
		{
			for (int x = 0; x < noiseTexture.width; x++)
			{
				float xCoord = xOrigin + (float)x / noiseTexture.width * scale;
				float yCoord = yOrigin + (float)y / noiseTexture.height * scale;
				int pixelIndex = y * noiseTexture.width + x;

				//pixels[pixelIndex] = new Color(sample, sample, sample);
				pixels[pixelIndex] = Color.Lerp(Color.black, Color.white, Mathf.PerlinNoise(xCoord, yCoord));
			}
		}

		noiseTexture.SetPixels(pixels);
		noiseTexture.Apply();


		textureRenderer.material.mainTexture = noiseTexture;

		//TODO: What does this even do?
		//textureRenderer.transform.localScale = new Vector3(pixelWidth, 1, pixelHeight);
	}
}
