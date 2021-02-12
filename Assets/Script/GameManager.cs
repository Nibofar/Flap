using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public enum GameState
{
    MainMenu,
    InGame,
    Pause,
    Death,
}
public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.LogError("The GameManager is null");
            }
            return _instance;
        }
    }
    private static GameState _gameState;
    public static GameState State
    {
        get
        {
            return _gameState;
        }
    }
    AudioSource audioSource;
    public bool collade = false;
    private float score;
    void Awake()
    {
        _instance = this;
        score = 0;
        _gameState = 0;
    }
    void Start()
    {
        UIManager.Instance.countText.text = "Score = " + score;
        audioSource = GetComponent<AudioSource>();
    }
    void Update()
    {
        if (Input.GetKeyDown("p"))
        {
            ChangeState(GameState.Pause);
        }
    }
    public void ChangeState(GameState state)
    {
        _gameState = state;
        switch (_gameState)
        {
            case GameState.MainMenu:
                this.Menu();
                Debug.Log("MainMenu");
                break;
            case GameState.InGame:
                this.Game();
                Debug.Log("Game");
                break;
            case GameState.Pause:
                Debug.Log("Pause");
                this.Pause();
                break;
            case GameState.Death:
                this.Death();
                Debug.Log("Death");
                break;
        }
    }
    void Menu()
    {

    }
    void Game()
    {
        
    }
    void Pause()
    {
        UIManager.Instance.playButton.SetActive(true);
    }
    void Death()
    {
        collade = true;
    }
    public void PlaySound(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }
    public void UpdateScore()
    {
        _instance.score += 1;
        UIManager.Instance.countText.text = "Score = " + _instance.score;
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
