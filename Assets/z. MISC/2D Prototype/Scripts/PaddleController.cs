/*
* Copyright (c) Kp4ws
*
*/

using UnityEngine;

public class PaddleController : MonoBehaviour
{
	[SerializeField] private GameSession2D gameSession;

	private float screenWidthInUnits = 22f;
	private float skinWidth = 1.15f;
	private float minX = 1f;
	private float maxX = 21f;

	private BallController ball;

	private void Start()
	{
		ball = FindObjectOfType<BallController>();
	}

	private void Update()
	{
		if (!GameSession2D.IsGamePaused())
		{
			Vector2 paddlePos = new Vector2(transform.position.x, transform.position.y);
			paddlePos.x = Mathf.Clamp(GetXPos(), minX + skinWidth, maxX - skinWidth);
			transform.position = paddlePos;
		}
	}

	private float GetXPos()
	{
		if (gameSession.IsAutoPlayEnabled())
		{
			return ball.transform.position.x;
		}

		return Input.mousePosition.x / Screen.width * screenWidthInUnits;
	}
}

