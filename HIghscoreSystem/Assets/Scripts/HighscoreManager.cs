using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class HighscoreManager : MonoBehaviour
{
    public TextMeshProUGUI highscoreText;
    public TextMeshProUGUI currentScoreText;
    public float currentScore = 0.0f;
    public float highscore = 0.0f;
    public bool isRunning = false;
    private string highscoreKey = "Highscore";

    private void Start()
    {
        highscore = PlayerPrefs.GetFloat(highscoreKey, 0.0f);
        UpdateCurrentScoreText();
        UpdateHighscoreText();
    }

    private void Update()
    {
        if (isRunning)
        {
            currentScore += Time.deltaTime;
            if (currentScore > highscore)
            {
                highscore = currentScore;
                PlayerPrefs.SetFloat(highscoreKey, highscore);
                UpdateHighscoreText();
            }
            UpdateCurrentScoreText();
        }

    }

    public void StartTimer()
    {
        isRunning = true;
    }

    public void StopTimer()
    {
        isRunning = false;
    }

    private void UpdateCurrentScoreText()
    {
        currentScoreText.text = "Time To Alive : " + FormatTime(currentScore);
    }

    private void UpdateHighscoreText()
    {
        highscoreText.text = "Your Best Time : " + FormatTime(highscore);
    }

    private string FormatTime(float time)
    {
        int minutes = Mathf.FloorToInt(time / 60);
        int seconds = Mathf.FloorToInt(time % 60);

        return string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public void DeleteHighscore()
    {
        PlayerPrefs.DeleteKey(highscoreKey);
        UpdateHighscoreText();
    }
}
