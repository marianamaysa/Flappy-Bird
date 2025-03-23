using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("Game Over")]
    public static GameManager instance;
    [SerializeField] private GameObject gameOverCanvas;

    [Header("Star Game")]
    private bool gameStart = false;

    private void Awake()
    {
        if (instance == null)
            instance = this;

        Time.timeScale = 1f;
    }

    private void Start()
    {
        Time.timeScale = 0f;
    }

    private void Update()
    {
        if (!gameStart && Input.GetKeyDown(KeyCode.Space))
        {
            GameStart();
        }
    }

    public void GameStart()
    {
        gameStart = true;
        Time.timeScale = 1f;
    }

    public void GameOver()
    {
        gameOverCanvas.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
