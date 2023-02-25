using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverPanel : MonoBehaviour
{

    public FloatVariable score;
    public FloatVariable highScore;
    public BoolVariable playerAlive;

    public Image medalImage;

    public Sprite bronzeStar;
    public Sprite silverStar;
    public Sprite goldStar;

    public int goldMinScore;
    public int silverMinScore;

    public Text newHighScoreLabel;


    bool visible;

    private void Awake()
    {
        transform.localScale = Vector3.zero;
        score.SetValue(0);
        Time.timeScale = 0f;

        if (PlayerPrefs.HasKey("HighScore"))
        {
            highScore.value = PlayerPrefs.GetFloat("HighScore");
        }
        else
        {
            PlayerPrefs.SetFloat("HighScore", 0);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(playerAlive.value == true)
        {
            if(Time.timeScale > 0f)
            {
                score.ApplyChange(Time.deltaTime * 100);
            }
        }
        else if(visible != true)
        {
            GameOver();
        }
    }
    void GameOver()
    {
        visible = true;
        Time.timeScale = 0f;

        if(score.value > goldMinScore)
        {
            medalImage.sprite = goldStar;
        }
        else if(score.value > silverMinScore)
        {
            medalImage.sprite = silverStar;
        }
        else
        {
            medalImage.sprite = bronzeStar;
        }

        if(score.value < highScore.value)
        {
            newHighScoreLabel.transform.localScale = Vector3.zero;
        }
        else
        {
            highScore.SetValue(score.value);
            PlayerPrefs.SetFloat("HighScore", score.value);
        }

        transform.localScale = Vector3.one;
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
