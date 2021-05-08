using UnityEngine;
using TMPro;

public class EndlessGame : MonoBehaviour
{
	[SerializeField] private TextMeshProUGUI scoreText;
	private float score;

	private void Update()
	{
		if (scoreText)
		{
			score += Time.deltaTime;
			scoreText.text = "Time: " + Mathf.Round(score).ToString(); //TODO for the time being I'm just using this as time passed and not score
		}
	}
}
