/*
* Copyright (c) Kp4ws
*
*/

using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
	private const string START_SCENE = "Start Menu";
	private const string OPTIONS_SCENE = "Options Menu";
	private const string GAME_SCENE = "Game Scene";
	private const string GAMEOVER_SCENE = "Gameover Scene";
	private const string CREDITS_SCENE = "Credits Scene";

	private void ResetGameSession()
	{
		GameSession2D gameSession = FindObjectOfType<GameSession2D>();

		if (gameSession)
		{
			gameSession.ResetGame();
		}
	}

	public void LoadStartScene()
	{
		SceneManager.LoadScene(START_SCENE);
		ResetGameSession();
	}

	public void LoadGameScene()
	{
		SceneManager.LoadScene(GAME_SCENE);
		ResetGameSession();
	}

	public void LoadGameoverScene()
	{
		SceneManager.LoadScene(GAMEOVER_SCENE);
	}

	public void LoadOptions()
	{
		SceneManager.LoadScene(OPTIONS_SCENE);
	}

	public void LoadCredits()
	{
		SceneManager.LoadScene(CREDITS_SCENE);
	}

	public void QuitGame()
	{
		Application.Quit();
	}

	public void OpenURL()
	{
		Application.OpenURL("http://nosoapradio.us/");
	}
}
