﻿/*
* Copyright (c) Kp4ws
*
*/

using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
	private static AudioSource audioSource;
	private void Start()
	{
		audioSource = GetComponent<AudioSource>();
		audioSource.volume = PlayerPrefsController.GetMasterVolume();
	}
	
	public static void PauseMusic()
	{
		audioSource.Pause();
	}

	public static void ResumeMusic()
	{
		audioSource.UnPause();
	}
}

