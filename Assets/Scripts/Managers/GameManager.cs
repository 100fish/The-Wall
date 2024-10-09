using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int baseHealth = 100;
    public int health = 100;
    public float roundTime = 0;

    public GameObject menuPanel;
    public GameObject gameplayPanel;

    public Button newGameButton;

    public EnemySpawner enemySpawner;

    public static GameManager Instance;

    public enum GameState
    {
        Start,
        Playing,
        GameOver
    };

    public GameState gameState;

    public GameState State { get { return gameState; } }

    private void Awake()
    {
        if (Instance != null)
            Destroy(this);
        Instance = this;
        gameState = GameState.GameOver;
        
    }

    void Update()
    {

        if (Input.GetKeyUp(KeyCode.Escape))
        {
            Application.Quit();
        }

        switch (gameState)
        {
            case GameState.Start:
                GameStateStart();
                break;
            case GameState.Playing:
                GameStatePlaying();
                break;
            case GameState.GameOver:
                GameStateGameOver();
                break;
            default:
                break;
        }
    }

    //activates once the start button is pressed, after a countdown it initliases all the values in order for the game to be playable.
    private void GameStateStart()
    {
        menuPanel.SetActive(false);
        gameplayPanel.SetActive(true);
        gameState = GameState.Playing;
        roundTime = 0;
        health = baseHealth;

    }


    private void GameStatePlaying()
    {
        roundTime += Time.deltaTime;

        if (health < 1)
        {
            gameState = GameState.Start;
            foreach (GameObject enemy in enemySpawner.enemyList)
            {
                Destroy(enemy);
            }
            gameplayPanel.SetActive(false);
            menuPanel.SetActive(true);
        }
    }

    private void GameStateGameOver()
    {

    }

    public void OnNewGame()
    {
        gameState = GameState.Start;
    }

}