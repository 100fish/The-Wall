using System;
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
    public int money = 5;
    public float timerFPS = 30;
    public float timerFPSAmount = 30;

    bool changingToFPS;
    bool changingToTDF;

    public GameObject menuPanel;
    public GameObject gameplayPanel;
    public GameObject gameplayPanelFPS;

    public Camera TDFcam;
    public Camera FPScam;

    public TextMeshProUGUI FPSmoney;
    public TextMeshProUGUI FPStime;

    public TextMeshProUGUI moneyText; 
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI titleText;
    public Button newGameButton;
    private GameObject empty;

    public CharacterController fpsCC;

    public EnemySpawner enemySpawner;

    public static GameManager Instance;

    public enum GameState
    {
        Start,
        PlayingTDF,
        PlayingFPS,
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
        empty = new GameObject();
        titleText.text = "Welcome to FPFTD!";
        gameplayPanel.SetActive(false);
        gameplayPanelFPS.SetActive(false);
        TDFcam.enabled = true;
        FPScam.enabled = false;
        fpsCC.enabled = false;
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
            case GameState.PlayingTDF:
                GameStatePlayingTDF();
                break;
            case GameState.PlayingFPS:
                GameStatePlayingFPS();
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
        gameState = GameState.PlayingTDF;
        roundTime = 0;
        health = baseHealth;

    }


    private void GameStatePlayingTDF()
    {
        roundTime += Time.deltaTime;
        healthText.text = "Base health: " + health;
        moneyText.text = "You have $" + money;

        if (health < 1)
        {
            gameState = GameState.GameOver;
            foreach (GameObject enemy in enemySpawner.enemyList)
            {
                Destroy(enemy);
            }
            gameplayPanel.SetActive(false);
            menuPanel.SetActive(true);
            titleText.text = "Your base was destroyed";
        }
        else if (changingToFPS)
        {
            gameplayPanel.SetActive(false);
            gameplayPanelFPS.SetActive(true);

            TDFcam.enabled = !TDFcam.enabled;
            FPScam.enabled = !FPScam.enabled;

            fpsCC.enabled = true;
            Cursor.lockState = CursorLockMode.Locked;

            gameState = GameState.PlayingFPS;
            changingToFPS = false;
        }
    }

    private void GameStatePlayingFPS()
    {
        timerFPS -= Time.deltaTime;
        FPSmoney.text = "You have $" + money;

        int seconds = Mathf.RoundToInt(timerFPS);
        FPStime.text = string.Format("Time: {0:D2}:{1:D2}",
                              (seconds / 60), (seconds % 60));
        if (timerFPS <= 0 || changingToTDF)
        {
            timerFPS = timerFPSAmount;

            gameplayPanel.SetActive(true);
            gameplayPanelFPS.SetActive(false);

            TDFcam.enabled = !TDFcam.enabled;
            FPScam.enabled = !FPScam.enabled;

            fpsCC.enabled = false;
            Cursor.lockState = CursorLockMode.Confined;

            gameState = GameState.PlayingTDF;
            changingToTDF = false;
        }
    }

    private void GameStateGameOver()
    {
        
    }

    public void OnNewGame()
    {
        gameState = GameState.Start;
    }

    public void ChangeMode()
    {
        if (gameState == GameState.PlayingTDF)
        {
            changingToFPS = true;
        }
        else if (gameState == GameState.PlayingFPS)
        {
            changingToTDF = true;
        }
    }

    public void Kill(GameObject target)
    {
        //gets the enemy id from the enemy gameobject name
        char[] idGet = { 'e', 'n', 'm', 'y' };
        int deathID = Int32.Parse(target.name.TrimStart(idGet));

        Destroy(target); //kills the enemy

        //replaces the enemy position in the list with an empty gameobject
        Debug.Log("DeathID is " + deathID);
        enemySpawner.enemyList[deathID] = Instantiate(empty);
        enemySpawner.enemyList[deathID].gameObject.tag = "ShootIgnore";

        Debug.Log("ID slot is " + enemySpawner.enemyList[deathID]);
        Debug.Log("DEATH for " + target.name);
    }

}