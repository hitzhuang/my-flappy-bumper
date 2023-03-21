using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{
    public bool isGameActive = true;
    public int playerScore = 0;
    public Text scoreText;
    public Text highScoreText;
    public GameObject gameOverUI;

    private int highScore = 0;

    void Start()
    {
        highScore = PlayerPrefs.GetInt("HighScore");
        setHighScore(highScore);
    }

    [ContextMenu("Increase Score")]
    public void addScore(int scoreToAdd)
    {
        if (isGameActive)
        {
            playerScore += scoreToAdd;
            scoreText.text = playerScore.ToString();

            if (highScore < playerScore)
            {
                setHighScore(playerScore);
            }
        }
    }

    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void gameOver()
    {
        isGameActive = false;
        gameOverUI.SetActive(true);
    }

    private void setHighScore(int score)
    {
        highScore = score;
        highScoreText.text = "High Score: " + score.ToString();
        PlayerPrefs.SetInt("HighScore", score);
    }
}
