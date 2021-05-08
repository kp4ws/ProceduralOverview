/*
* Copyright (c) Kp4ws
*
*/

using UnityEngine;
using TMPro;
public class NextWave : MonoBehaviour
{
	[SerializeField] private TextMeshProUGUI countdownText;
	public float countdownTimer = 3;

	private void Update()
	{
		countdownTimer -= Time.deltaTime;
		countdownText.text = Mathf.Round(countdownTimer).ToString();

		if(countdownTimer < 1)
		{
			FindObjectOfType<LevelController>().GenerateBlocks();
			countdownTimer = 3;
			gameObject.SetActive(false);
		}
	}
}

 