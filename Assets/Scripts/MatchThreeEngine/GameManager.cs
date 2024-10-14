using MatchThreeEngine;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using YG;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance { get; private set; }

    [SerializeField] private Board board;
    [SerializeField] private GameObject endGameMenu;
    [SerializeField] private float gameTimer = 60;

    [SerializeField] private TextMeshProUGUI scoreText, timerText, endGameScoreText;

    private int score = 0;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        scoreText.text = score.ToString();
    }

    private void Update()
    {
        if (gameTimer <= 0)
        {
            GameEnded();
        }
        else
        {
            gameTimer -= Time.deltaTime;
            timerText.text = TimeSpan.FromSeconds(gameTimer).ToString(@"mm\:ss");
        }
    }

    private void GameEnded()
    {
        board.isGameEnded = true;
        endGameScoreText.text = score.ToString();
        endGameMenu.SetActive(true);
        if (YandexGame.savesData.best < score)
        {
            YandexGame.savesData.best = score;
            YandexGame.SaveProgress();
            YandexGame.NewLeaderboardScores("BestPlayers", score);
        }
    }

    public static void RestartGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    public static void MainMenu()
    {
        SceneManager.LoadScene("MainMenuScene");
    }

    public void AddScore(int score)
    {
        this.score += score;
        scoreText.text = this.score.ToString();
    }

}
