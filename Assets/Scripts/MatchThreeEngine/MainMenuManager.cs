using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using YG;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI bestText;
    private bool isLeaderboardActive;
    [SerializeField] private GameObject leaderboard;
    private LeaderboardYG leaderboardScript;

    private void Start()
    {
        if (YandexGame.SDKEnabled)
        {
            GetLoad();
        }
        leaderboardScript = leaderboard.GetComponent<LeaderboardYG>();
    }

    private void OnEnable()
    {
        YandexGame.GetDataEvent += GetLoad;
    }

    private void OnDisable()
    {
        YandexGame.GetDataEvent -= GetLoad;
    }

    private void GetLoad()
    {
        bestText.text = YandexGame.savesData.best.ToString();
    }

    public static void StartGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void OnLiderboardToggle()
    {
        leaderboardScript.UpdateLB();
        isLeaderboardActive = !isLeaderboardActive;
        leaderboard.SetActive(isLeaderboardActive);
    }
}
