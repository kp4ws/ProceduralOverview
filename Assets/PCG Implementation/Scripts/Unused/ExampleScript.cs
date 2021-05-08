using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExampleScript : MonoBehaviour
{
	[Header("Testing Purposes")] [SerializeField] private bool autoGenerate = true;

	//width and height of texture in pixels
	[SerializeField] private int pixelWidth = 300;
	[SerializeField] private int pixelHeight = 300;

	private int tempWidth;
	private int tempHeight;

	//origin of sampled area in the plane
	[SerializeField] private float xOrigin;
	[SerializeField] private float yOrigin;

	//Number of cycles of the basic noise pattern that are repeated over the width and height of the texture
	[SerializeField] private float scale = 20.0f;

	private Texture2D noiseTexture;
	private Color[] pixels;
	private Renderer textureRenderer;

	private void Start()
	{
		textureRenderer = GetComponent<Renderer>();
		tempWidth = pixelWidth;
		tempHeight = pixelHeight;

		UpdateTexture();
	}

	private void Update()
	{
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
			textureRenderer.material.mainTexture = CalcNoise();
		}
	}

	private void UpdateTexture()
	{
		//Set up the texture and a Color array to hold pixels during processing.
		noiseTexture = new Texture2D(pixelWidth, pixelHeight);
		pixels = new Color[noiseTexture.width * noiseTexture.height];
	}

	private Texture2D CalcNoise()
	{
		//For each pixel in the texture
		for (int y = 0; y < noiseTexture.height; y++)
		{
			for (int x = 0; x < noiseTexture.width; x++)
			{
				float xCoord = xOrigin + (float)x / noiseTexture.width * scale;
				float yCoord = yOrigin + (float)y / noiseTexture.height * scale;

				float sample = Mathf.PerlinNoise(xCoord, yCoord);

				int pixelIndex = y * noiseTexture.width + x;

				pixels[pixelIndex] = new Color(sample, sample, sample);
			}
		}

		//Copy the pixel data to the texture and load it into the GPU
		noiseTexture.SetPixels(pixels);
		noiseTexture.Apply();

		return noiseTexture;
	}
}
