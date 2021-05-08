/*
* Copyright (c) Kp4ws
*
*/

using UnityEngine;
using TMPro;

public class GameSession2D : MonoBehaviour
{
	[Tooltip("Testing Purposes")] [SerializeField] private bool autoPlay;
	[SerializeField] private bool generateNextLevel;
	[SerializeField] private GameObject nextWave;

	[SerializeField] private TextMeshProUGUI scoreText;
	[SerializeField] private TextMeshProUGUI livesText;
	[SerializeField] GameObject pauseMenu;


	private const float EASY_SPEED = 0.8f;
	private const float NORMAL_SPEED = 1f;
	private const float HARD_SPEED = 1.5f;

	private float gameSpeed;
	private static int currentScore = 0;
	private int lives;
	private int baseLives = 3;

	private static bool gamePaused = false;

	public static int GetCurrentScore()
	{
		return currentScore;
	}

	public static bool IsGamePaused()
	{
		return gamePaused;
	}

	private void Awake()
	{
		int gameSessionAmount = FindObjectsOfType<GameSession2D>().Length;

		if (gameSessionAmount > 1)
		{
			gameObject.SetActive(false);
			Destroy(gameObject);
		}
		else
		{
			DontDestroyOnLoad(gameObject);
		}
	}

	private void Start()
	{
		lives = baseLives - PlayerPrefsController.GetDifficulty();
		switch (PlayerPrefsController.GetDifficulty())
		{
			//Easy
			case 0:
				gameSpeed = EASY_SPEED;
				break;
			//Normal
			case 1:
				gameSpeed = NORMAL_SPEED;
				break;
			//Hard
			case 2:
				gameSpeed = HARD_SPEED;
				break;

			default:
				Debug.LogError("Invalid Difficulty");
				break;
		}

		UpdateScoreGUI();
		UpdateLivesGUI();

		Time.timeScale = gameSpeed;
	}

	private void Update()
	{
		if (generateNextLevel)
		{
			var objects = FindObjectsOfType<BlockController>();
			foreach (BlockController o in objects)
			{
				Destroy(o.gameObject);
			}
			nextWave.SetActive(true);
			generateNextLevel = false;
			Debug.Log("Next Wave Generated");
		}


		if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
		{
			gamePaused = !gamePaused;
			PauseGame();
		}
	}

	private void PauseGame()
	{
		if (gamePaused)
		{
			Time.timeScale = 0;
			pauseMenu.SetActive(true);
			MusicPlayer.PauseMusic();
		}
		else
		{
			ResumeGame();
		}
	}

	public void ResumeGame()
	{
		Time.timeScale = gameSpeed;
		gamePaused = false;
		pauseMenu.SetActive(false);
		MusicPlayer.ResumeMusic();
	}

	public void TakeLife()
	{
		lives--;
		UpdateLivesGUI();

		if (lives < 0)
		{
			if (FindObjectOfType<SceneLoader>())
				FindObjectOfType<SceneLoader>().LoadGameoverScene();
		}
		else
		{
			FindObjectOfType<BallController>().ResetBall();
		}
	}

	public void AddToScore(int amount)
	{
		currentScore += amount;
		UpdateScoreGUI();

		if (currentScore > PlayerPrefsController.GetHighScore())
		{
			PlayerPrefsController.SetHighScore(currentScore);
		}
	}

	private void UpdateScoreGUI()
	{
		if (scoreText == null)
		{
			Debug.LogError("Score text hasn't been set in GameSession");
			return;
		}

		scoreText.text = "Score: " + currentScore.ToString();
	}

	private void UpdateLivesGUI()
	{
		if (livesText == null)
		{
			Debug.LogError("Lives text hasn't been set in GameSession");
			return;
		}

		livesText.text = "Lives: " + lives.ToString();
	}

	public void ResetGame()
	{
		Destroy(gameObject);
		gamePaused = false;
		currentScore = 0;
	}

	public bool IsAutoPlayEnabled()
	{
		return autoPlay;
	}

}

