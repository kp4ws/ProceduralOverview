/*
* Copyright (c) Kp4ws
*
*/

using System;
using UnityEngine;

public class BlockController : MonoBehaviour
{
	private const string BREAKABLE = "Breakable";

	[SerializeField] private AudioClip breakSound;
	[SerializeField] private GameObject blockVFX;
	[SerializeField] private Sprite[] hitSprites;
	[SerializeField] private int blockPointsPerDestroyed;

	private int timesHit;
	private float delayVFX = 1f;

	LevelController level;

	private void Start()
	{
		GetComponent<AudioSource>().volume = PlayerPrefsController.GetMasterVolume();
		CountBreakableBlocks();
	}

	private void CountBreakableBlocks()
	{
		level = FindObjectOfType<LevelController>();

		if (tag == BREAKABLE && level)
		{
			level.CountBlocks();
		}
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (tag == BREAKABLE)
		{
			HandleHit();
		}
	}

	private void HandleHit()
	{
		timesHit++;
		int maxHits = hitSprites.Length + 1;

		if (timesHit >= maxHits)
		{
			DestroyBlock();
		}
		else
		{
			ShowNextHitSprite();
		}
	}

	private void ShowNextHitSprite()
	{
		int spriteIndex = timesHit - 1;
		if (hitSprites[spriteIndex] != null)
		{
			GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
		}
		else
		{
			Debug.LogError("Block sprite is missing from array" + gameObject.name);
		}
	}

	private void DestroyBlock()
	{
		PlayBlockDestroyedSFX();
		Destroy(gameObject);

		if (level)
			level.BlockDestroyed();

		FindObjectOfType<GameSession2D>().AddToScore(blockPointsPerDestroyed);
	}

	private void PlayBlockDestroyedSFX()
	{
		if (breakSound == null)
		{
			Debug.LogError("Break sound is not set " + gameObject.name);
			return;
		}

		if (blockVFX == null)
		{
			Debug.LogError("Block VFX is not set");
			return;
		}

		AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
		GameObject particles = Instantiate(blockVFX, transform.position, Quaternion.identity);
		Destroy(particles, delayVFX);
	}
}

