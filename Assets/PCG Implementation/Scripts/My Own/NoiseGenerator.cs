using UnityEngine;

public class NoiseGenerator : MonoBehaviour
{
	public float[,] CreateNoiseMap(int mapWidth, int mapHeight, float xOrigin, float yOrigin, float scale, Wave[] waves)
	{
		float[,] noiseMap = new float[mapWidth, mapHeight];
		//For each pixel in the texture
		for (int y = 0; y < mapHeight; y++)
		{
			for (int x = 0; x < mapWidth; x++)
			{
				float xCoord = xOrigin + (float)x / mapWidth * scale;
				float yCoord = yOrigin + (float)y / mapHeight * scale;

				float sample = 0;
				float normalization = 0f;

				foreach(Wave wave in waves)
				{
					sample += wave.amplitude * Mathf.PerlinNoise(xCoord * wave.frequency + wave.seed, yCoord * wave.frequency + wave.seed);
					normalization += wave.amplitude;
				}

				sample /= normalization;
				noiseMap[y, x] = sample;
			}
		}
		return noiseMap;
	}
}

[System.Serializable]
public class Wave
{
	public float seed;
	public float frequency;
	public float amplitude;
}
