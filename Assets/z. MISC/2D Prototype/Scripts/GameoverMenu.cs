/*
* Copyright (c) Kp4ws
*
*/

using UnityEngine;
using TMPro;

public class GameoverMenu : MonoBehaviour
{
	[SerializeField] TextMeshProUGUI scoreValue;
	[SerializeField] TextMeshProUGUI highScoreValue;

	private void Start()
	{
		scoreValue.text = GameSession2D.GetCurrentScore().ToString();
		highScoreValue.text = PlayerPrefsController.GetHighScore().ToString();
	}
}

