/*
* Copyright (c) Kp4ws
*
*/

using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class OptionsMenu : MonoBehaviour
{
	[SerializeField] private string[] difficulties;
	[SerializeField] private Slider volumeSlider;
	[SerializeField] private TextMeshProUGUI difficultyText;

	private int selectedDifficulty;

	private void Start()
	{
		volumeSlider.value = PlayerPrefsController.GetMasterVolume();
		selectedDifficulty = PlayerPrefsController.GetDifficulty();
		UpdateDifficultyGUI();
	}

	public void difficultyRight()
	{
		selectedDifficulty = selectedDifficulty < difficulties.Length - 1 ? ++selectedDifficulty : 0;
		UpdateDifficultyGUI();
	}

	public void difficultyLeft()
	{
		selectedDifficulty = selectedDifficulty > 0 ? --selectedDifficulty : difficulties.Length - 1;
		UpdateDifficultyGUI();
	}

	private void UpdateDifficultyGUI()
	{
		difficultyText.text = difficulties[selectedDifficulty];
	}

	public void SaveAndExit()
	{
		PlayerPrefsController.SetMasterVolume(volumeSlider.value);
		PlayerPrefsController.SetDifficulty(selectedDifficulty);
		FindObjectOfType<SceneLoader>().LoadStartScene();
	}
}

