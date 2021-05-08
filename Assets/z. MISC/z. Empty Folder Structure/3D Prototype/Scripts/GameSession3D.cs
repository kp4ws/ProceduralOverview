using UnityEngine;
using TMPro;
using System;

public class GameSession3D : MonoBehaviour
{
	[SerializeField] private TextMeshProUGUI scoreText;
	private int currentScore = 0;
	private bool attack = true;

	private void Start()
	{
		scoreText.text = "Score: " + currentScore.ToString();
	}

	public void IncrementScore()
	{
		currentScore++;
		scoreText.text = "Score: " + currentScore.ToString();
	}

	public void ToggleAttack()
	{
		attack = !attack;
	}

	public bool IsAttacking()
	{
		return attack;
	}
}
