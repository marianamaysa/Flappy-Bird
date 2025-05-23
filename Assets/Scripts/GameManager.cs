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
    public GameObject menu;
    public GameObject tutorial;

    [Header("Pause Game")]
    public GameObject pauseCanvas;

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
        if (!gameStart && Input.GetMouseButtonDown(0))
        {
            menu.SetActive(false);
            tutorial.SetActive(true);
        }

        if (tutorial.activeSelf && Input.GetKeyDown(KeyCode.Space))
        {
            tutorial.SetActive(false);
            GameStart();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Time.timeScale == 1f)
            {
                Pause();
            }
            else if (Time.timeScale == 0f)
            {
                Resume();
            }
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

    public void Pause()
    {
        pauseCanvas.SetActive(true);
        Time.timeScale = 0;
    }

    public void Resume()
    {
        pauseCanvas.SetActive(false);
        Time.timeScale = 1;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
