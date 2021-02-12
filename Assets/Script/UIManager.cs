using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private static UIManager _instance;
    public static UIManager Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.LogError("The UIManager is null");
            }
            return _instance;
        }
    }
    public bool collade = false;
    public GameObject retryButton;
    public GameObject playButton;
    public Text countText;
    private void Awake()
    {
        _instance = this;
    }
    void Update()
    {
        if (GameManager.State == GameState.Death || GameManager.State == GameState.InGame)
        {
            playButton.SetActive(false);
        }
        if (GameManager.State == GameState.Death)
        {
            retryButton.SetActive(true);
        }
    }
    public void RestartClick()
    {
        GameManager.Instance.RestartGame();
    }
    public void PlayClick()
    {
        GameManager.Instance.ChangeState(GameState.InGame);
    }
}
