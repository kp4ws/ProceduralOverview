/*
* Copyright (c) Kp4ws
*
*/

using UnityEngine;

public class BallController : MonoBehaviour
{
	//Config
	[SerializeField] private PaddleController paddle;
	[SerializeField] private AudioClip[] ballSounds;
	[SerializeField] private float randomFactor = 1f;

	private const string PADDLE = "Paddle";

	//State
	private float xPush = 2f;
	private float yPush = 15f;
	Vector2 paddleToBallDistance;
	Vector2 originalPos;

	//Cached references
	private Rigidbody2D rb;
	private AudioSource audioSource;

	private bool ballLaunched = false;

	private void Start()
	{
		rb = GetComponent<Rigidbody2D>();
		audioSource = GetComponent<AudioSource>();
		paddleToBallDistance = transform.position - paddle.transform.position;

		audioSource.volume = PlayerPrefsController.GetMasterVolume(); //Unless I add music, this is the only place where I actually have volume
		originalPos = new Vector2(transform.position.x, transform.position.y);
	}

	private void Update()
	{
		if (!ballLaunched)
		{
			LockBallToPaddle();
			LaunchBall();
		}
	}

	private void LockBallToPaddle()
	{
		Vector2 paddlePos = new Vector2(paddle.transform.position.x, paddle.transform.position.y);
		transform.position = paddlePos + paddleToBallDistance;
	}

	private void LaunchBall()
	{
		if (Input.GetMouseButtonDown(0) && !GameSession2D.IsGamePaused())
		{
			rb.velocity = new Vector2(xPush, yPush);
			ballLaunched = true;
		}
	}

	public void ResetBall()
	{
		transform.position = originalPos;
		ballLaunched = false;
	}
	
	private void OnCollisionEnter2D(Collision2D collision)
	{
		Vector2 velocityTweak = new Vector2(Random.Range(0, randomFactor), Random.Range(0, randomFactor));

		if (ballLaunched)
		{
			AudioClip audioClip = ballSounds[Random.Range(0, ballSounds.Length)];
			audioSource.PlayOneShot(audioClip);

			if (collision.gameObject.name == PADDLE)
			{
				float x = (transform.position.x - paddle.transform.position.x) / collision.collider.bounds.size.x;
				Vector2 dir = new Vector2(x, 1).normalized;
				rb.velocity = dir * yPush;
			}
			else
			{
				rb.velocity += velocityTweak;
			}
		}
	}
}

